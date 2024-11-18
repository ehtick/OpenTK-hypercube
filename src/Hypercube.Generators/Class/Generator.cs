using System.Text;
using JetBrains.Annotations;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Hypercube.Generators.Class;

[PublicAPI]
public abstract class Generator : Generator<GeneratorOptions>;

[PublicAPI]
public abstract class Generator<T> : ISourceGenerator where T : GeneratorOptions
{
    protected static readonly char[] NewLineSeparators = ['\n', '\r'];
    
    protected virtual T[] Options { get; } = [];
    
    public void Initialize(GeneratorInitializationContext context)
    {
    }

    public void Execute(GeneratorExecutionContext context)
    {
        foreach (var option in Options)
        {
            GenerateSource(context, option);
        }
    }

    /// <summary>
    /// Creates one file with the specified settings and adds it to the sources.
    /// </summary>
    protected virtual void GenerateSource(GeneratorExecutionContext context, T options)
    {
        var fileContent = GetSource(context, options.File);
        var content = new StringBuilder();
        
        GenerateHeader(context, content, options, fileContent);
        GenerateUsings(context, content, options, fileContent);
        GenerateNamespace(context, content, options, fileContent);
        GenerateBody(context, content, options, fileContent);
                
        context.AddSource(options.SourcePath, SourceText.From(content.ToString(), Encoding.UTF8));
    }

    protected virtual void GenerateContent(GeneratorExecutionContext context, StringBuilder result,
        T options, string fileContent)
    {
        
    }

    protected string GetSource(GeneratorExecutionContext context, string file)
    {
        var source = context.AdditionalFiles
            .FirstOrDefault(text => text.Path.EndsWith(file))?
            .GetText(context.CancellationToken)?
            .ToString();

        if (!string.IsNullOrEmpty(source))
            return source;
        
        context.ReportDiagnostic(Diagnostic.Create(
            new DiagnosticDescriptor(
                "MYGEN001",
                "File Not Found",
                $"File {file} not found.",
                "Usage",
                DiagnosticSeverity.Warning,
                true
            ),
            Location.None
        ));

        return string.Empty;
    }

    private void GenerateHeader(GeneratorExecutionContext context, StringBuilder result, T options, string fileContent)
    {
        foreach (var line in options.Header)
        {
            var comment = line;
            comment = comment.Replace("${file}", options.File);
            comment = comment.Replace("${path}", options.SourcePath);
            
            result.AppendLine($"// {comment}");
        }

        result.AppendLine();
    }

    private void GenerateUsings(GeneratorExecutionContext context, StringBuilder result, T options, string fileContent)
    {
        foreach (var line in options.Usings)
        {
            result.AppendLine($"using {line};");
        }

        result.AppendLine();
    }

    private void GenerateNamespace(GeneratorExecutionContext context, StringBuilder result, T options, string fileContent)
    {
        result.AppendLine($"namespace {options.Namespace};");
        result.AppendLine();
    }

    private void GenerateBody(GeneratorExecutionContext context, StringBuilder result, T options, string fileContent)
    {
        result.AppendLine($"{options.Modifiers} {options.Type} {options.Name}");
        result.AppendLine("{");
        
        GenerateContent(context, result, options, fileContent);
        
        result.AppendLine("}");
    }

    protected static string UpperSnakeCaseToPascalCase(string source)
    {
        if (string.IsNullOrWhiteSpace(source))
            return string.Empty;
        
        var parts = source.Split('_', StringSplitOptions.RemoveEmptyEntries);
        for (var i = 0; i < parts.Length; i++)
        {
            parts[i] = char.ToUpper(parts[i][0]) + parts[i][1..].ToLowerInvariant();
        }
        
        return string.Concat(parts);
    }
}