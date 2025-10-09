using System.Reflection;
using Hypercube.Core.Execution.Attributes;
using Hypercube.Core.Execution.Enums;
using Hypercube.Utilities.Dependencies;
using Hypercube.Utilities.Extensions;
using Hypercube.Utilities.Helpers;

namespace Hypercube.Core.Execution;

public partial class Runtime
{
    private readonly Dictionary<EntryPointLevel, List<MethodInfo>> _entryPoints = [];
    
    private void EntryPointsLoad()
    {
        var methods = ReflectionHelper.GetExecutableMethodsWithAttributeFromAllAssemblies<EntryPointAttribute>(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
        foreach (var method in methods)
        {
            if (!method.IsStatic)
                throw new InvalidOperationException();
            
            var attribute = method.GetCustomAttribute<EntryPointAttribute>()!;
            _entryPoints.GetOrInstantiate(attribute.Level).Add(method);
            
            _logger.Debug($"Loaded {method.Name} entry point");
        }
    }
    
    private void EntryPointsExecute(EntryPointLevel level)
    {
        if (!_entryPoints.TryGetValue(level, out var entryPoints))
            return;
        
        foreach (var method in entryPoints)
        {
            var parameters = method.GetParameters();
            if (parameters.Length == 1)
            {
                if (parameters[0].ParameterType == typeof(DependenciesContainer))
                {
                    method.Invoke(null, [_dependencies]);
                    continue;
                }
                
                throw new InvalidOperationException();
            }
            
            method.Invoke(null, null);
        }
    }
}