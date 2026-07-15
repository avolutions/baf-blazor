using MudBlazor;

namespace Avolutions.Baf.Blazor.FileType;

public static class FileTypeIcons
{
    public static readonly (string Icon, Color Color) Folder =
        (Icons.Material.Filled.Folder, Color.Warning);

    public static readonly (string Icon, Color Color) Fallback =
        (Icons.Material.Filled.InsertDriveFile, Color.Default);

    public static (string Icon, Color Color) Get(string? fileExtension)
    {
        return Normalize(fileExtension) switch
        {
            "pdf" => (Icons.Custom.FileFormats.FilePdf, Color.Error),
            "doc" or "docx" => (Icons.Custom.FileFormats.FileWord, Color.Info),
            "xls" or "xlsx" => (Icons.Custom.FileFormats.FileExcel, Color.Success),
            "ppt" or "pptx" => (Icons.Material.Filled.Slideshow, Color.Error),
            "jpg" or "jpeg" or "png" or "gif" or "bmp" or "webp" => (Icons.Custom.FileFormats.FileImage, Color.Info),
            "mp3" or "wav" or "ogg" or "flac" => (Icons.Custom.FileFormats.FileMusic, Color.Default),
            "mp4" or "avi" or "mkv" or "mov" => (Icons.Custom.FileFormats.FileVideo, Color.Default),
            "zip" or "rar" or "7z" or "tar" or "gz" => (Icons.Material.Filled.FolderZip, Color.Warning),
            "txt" => (Icons.Custom.FileFormats.FileDocument, Color.Default),
            "cs" or "js" or "ts" or "py" or "java" or "cpp" or "html" or "css" => (Icons.Custom.FileFormats.FileCode, Color.Default),
            _ => Fallback,
        };
    }
    
    private static string Normalize(string? extension) =>
        (extension ?? string.Empty).TrimStart('.').ToLowerInvariant();
}