using System.Text;
using JetBrains.Annotations;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Hypercube.Generators.Class;

[PublicAPI]
public abstract class Generator : ISourceGenerator
{
    protected static readonly char[] NewLineSeparators = ['\n', '\r'];
    
    protected abstract string[] Header { get; }
    protected abstract string[] Usings { get; }
    protected abstract string Namespace { get; }
    protected abstract string Name { get; }
    protected abstract string Path { get; }
    protected abstract string Source { get; }
    protected abstract string Modifiers { get; }
    protected abstract string Type { get; }
    
    public void Initialize(GeneratorInitializationContext context)
    {
    }

    public void Execute(GeneratorExecutionContext context)
    {
        Setup(context);
        
        var source = GetSource(context, Source);
        var content = new StringBuilder();
        
        GenerateHeader(context, content, source);
        GenerateUsings(context, content, source);
        GenerateNamespace(context, content, source);
        GenerateBody(context, content, source);
                
        context.AddSource($"{Path}{Name}.g.cs", SourceText.From(content.ToString(), Encoding.UTF8));
    }

    protected virtual void Setup(GeneratorExecutionContext context)
    {
    }
    
    protected abstract void GenerateContent(GeneratorExecutionContext context, StringBuilder result, string source);

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

    private void GenerateHeader(GeneratorExecutionContext context, StringBuilder result, string source)
    {
        foreach (var line in Header)
        {
            result.AppendLine($"// {line}");
        }

        result.AppendLine();
    }

    private void GenerateUsings(GeneratorExecutionContext context, StringBuilder result, string source)
    {
        foreach (var line in Usings)
        {
            result.AppendLine($"using {line};");
        }

        result.AppendLine();
    }

    private void GenerateNamespace(GeneratorExecutionContext context, StringBuilder result, string source)
    {
        result.AppendLine($"namespace {Namespace};");
        result.AppendLine();
    }

    private void GenerateBody(GeneratorExecutionContext context, StringBuilder result, string source)
    {
        result.AppendLine($"{Modifiers} {Type} {Name}");
        result.AppendLine("{");

        GenerateContent(context, result, source);
        
        result.AppendLine("}");
    }
}