using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Hypercube.Core.Resources;

[PublicAPI]
public readonly struct ResourcePath
{
    /// <summary>
    /// Separator used in paths (Unix-style).
    /// </summary>
    public const char Separator = '/';
    
    /// <summary>
    /// Separator used in paths (Unix-style).
    /// </summary>
    public const string SeparatorStr = "/";

    /// <summary>
    /// Separator used in Windows paths.
    /// </summary>
    public const char WinSeparator = '\\';
    
    /// <summary>
    /// Separator used in Windows paths.
    /// </summary>
    public const string WinSeparatorStr = "\\";

    /// <summary>
    /// Platform-specific separator (depends on the operating system).
    /// </summary>
    public static readonly char SystemSeparator;

    /// <summary>
    /// Platform-specific separator as string (depends on the operating system).
    /// </summary>
    public static readonly string SystemSeparatorStr;

    /// <summary>
    /// Represents the current directory ("./").
    /// </summary>
    public static readonly ResourcePath Self = ".";

    /// <summary>
    /// The actual path represented by this instance.
    /// </summary>
    public string Path { get; }

    /// <summary>
    /// Static constructor to initialize platform-specific separators.
    /// </summary>
    static ResourcePath()
    {
        SystemSeparator = OperatingSystem.IsWindows() ? '\\' : '/';
        SystemSeparatorStr = OperatingSystem.IsWindows() ? "\\" : "/";
    }

    /// <summary>
    /// Constructor that initializes the path and converts it to the appropriate separator for the platform.
    /// </summary>
    /// <param name="path">The path string.</param>
    public ResourcePath(string path)
    {
        Path = OperatingSystem.IsWindows() ? path.Replace('\\', '/') : path;
    }

    /// <summary>
    /// Indicates whether the path is rooted (starts with the separator).
    /// </summary>
    public bool Rooted => Path.Length > 0 && Path[0] == Separator;

    /// <summary>
    /// Indicates whether the path is relative (does not start with the separator).
    /// </summary>
    public bool Relative => !Rooted;

    /// <summary>
    /// Indicates whether the path refers to the current directory (".").
    /// </summary>
    public bool IsSelf => Path == Self.Path;

    /// <summary>
    /// Extracts the filename with its extension from the path.
    /// </summary>
    public string FilenameWithExt
    {
        get
        {
            var sepIndex = Path.LastIndexOf(Separator) + 1;
            return sepIndex == -1 ? string.Empty : Path[sepIndex..];
        }
    }

    /// <summary>
    /// Extracts the file extension from the filename.
    /// </summary>
    public string Extension
    {
        get
        {
            var filename = FilenameWithExt;
            var extIndex = filename.LastIndexOf('.');
            return extIndex > 0 ? filename[extIndex..] : string.Empty;
        }
    }

    /// <summary>
    /// Extracts the filename without its extension.
    /// </summary>
    public string Filename
    {
        get
        {
            var filename = FilenameWithExt;
            var extIndex = filename.LastIndexOf('.');
            return extIndex > 0 ? filename[..extIndex] : filename;
        }
    }

    /// <summary>
    /// Returns the parent directory of the current path.
    /// </summary>
    public ResourcePath ParentDirectory
    {
        get
        {
            if (IsSelf)
                return Self;

            var lastIndex = Path.Length > 1 && Path[^1] == Separator
                ? Path[..^1].LastIndexOf(Separator)
                : Path.LastIndexOf(Separator);

            return lastIndex switch
            {
                -1 => Self,
                0 => new ResourcePath(Path[..1]),
                _ => new ResourcePath(Path[..lastIndex])
            };
        }
    }
    

    /// <summary>
    /// Tries to calculate the relative path to a given base path.
    /// </summary>
    public bool TryRelativeTo(ResourcePath basePath, [NotNullWhen(true)] out ResourcePath? relative)
    {
        if (this == basePath)
        {
            relative = Self;
            return true;
        }

        if (basePath == Self && Relative)
        {
            relative = this;
            return true;
        }

        if (Path.StartsWith(basePath.Path))
        {
            var x = Path[basePath.Path.Length..].Trim(Separator);
            relative = string.IsNullOrEmpty(x) ? Self : new ResourcePath(x);
            return true;
        }

        relative = null;
        return false;
    }

    /// <summary>
    /// Creates a ResourcePath from a relative system path, replacing the specified separator.
    /// </summary>
    public static ResourcePath FromRelativeSystemPath(string path, char newSeparator)
    {
        return new ResourcePath(path.Replace(newSeparator, Separator));
    }

    /// <summary>
    /// Compares two ResourcePath instances for equality.
    /// </summary>
    public static bool Equals(ResourcePath a, ResourcePath b)
    {
        return a.Path == b.Path;
    }

    /// <summary>
    /// Checks if the current ResourcePath is equal to another.
    /// </summary>
    public bool Equals(ResourcePath other)
    {
        return Path == other.Path;
    }
    
    public override bool Equals(object? obj)
    {
        if (obj is not ResourcePath other)
            return false;

        return Path == other.Path;
    }
    
    public override int GetHashCode()
    {
        return Path.GetHashCode();
    }
    
    public override string ToString()
    {
        return Path;
    }
    
    public static implicit operator ResourcePath(string path)
    {
        return new ResourcePath(path);
    }
    
    public static implicit operator string(ResourcePath path)
    {
        return path.Path;
    }
    
    public static ResourcePath operator +(ResourcePath left, ResourcePath right)
    {
        if (right.IsSelf)
            return left;

        if (right.Rooted)
            return right;

        if (left.Path == string.Empty)
            return new ResourcePath($"/{right.Path}");

        return left.Path.EndsWith(Separator)
            ? new ResourcePath(left.Path + right.Path)
            : new ResourcePath(left.Path + Separator + right.Path);
    }
    
    public static bool operator ==(ResourcePath left, ResourcePath right)
    {
        return left.Equals(right);
    }
    
    public static bool operator !=(ResourcePath left, ResourcePath right)
    {
        return !left.Equals(right);
    }
}