using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;

namespace Hypercube.Analyzers.Dependencies;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class DependencyRegistrationInterfaceValidationAnalyzer : DiagnosticAnalyzer
{
    private static readonly DiagnosticDescriptor Rule = new(
        id: "DI001",
        title: "Type must implement interface for DI registration",
        messageFormat: "Type '{0}' must implement interface '{1}' for DI registration",
        category: "Design",
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true);

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze | GeneratedCodeAnalysisFlags.ReportDiagnostics);
        context.EnableConcurrentExecution();
        context.RegisterSyntaxNodeAction(AnalyzeNode, SyntaxKind.InvocationExpression);
    }

    private static void AnalyzeNode(SyntaxNodeAnalysisContext context)
    {
        var invocationExpression = (InvocationExpressionSyntax)context.Node;

        // Check if the method is Register<TType, TImpl>()
        if (invocationExpression.Expression is not MemberAccessExpressionSyntax memberAccess ||
            memberAccess.Name.Identifier.Text != "Register")
            return;

        // Extract the type arguments (generic types in Register<TType, TImpl>())
        var argumentList = invocationExpression.ArgumentList.Arguments;
        if (argumentList.Count < 2)
            return;

        var firstTypeArg = argumentList[0].Expression;
        var secondTypeArg = argumentList[1].Expression;

        // Ensure that the arguments are types (e.g., `typeof(TType)` and `typeof(TImpl)`)
        var firstTypeSymbol = context.SemanticModel.GetSymbolInfo(firstTypeArg).Symbol as INamedTypeSymbol;
        var secondTypeSymbol = context.SemanticModel.GetSymbolInfo(secondTypeArg).Symbol as INamedTypeSymbol;

        if (firstTypeSymbol == null || secondTypeSymbol == null)
            return;

        // Check if the second type (TImpl) implements the first type (TType)
        if (secondTypeSymbol.AllInterfaces.Any(i => i.Equals(firstTypeSymbol, SymbolEqualityComparer.Default)))
            return;
        
        var diagnostic = Diagnostic.Create(Rule, invocationExpression.GetLocation(), secondTypeSymbol.Name, firstTypeSymbol.Name);
        context.ReportDiagnostic(diagnostic);
    }
}