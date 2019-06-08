using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monoedit
{
    public class Phrases
    {
        //**LEXICON MUST COME AT TOP
        //This does some crazy reverse lookups with a host of dictionaries for performance.
        public static Dictionary<LanguageCode, Dictionary<int, Phrase>> Lexicon = new Dictionary<LanguageCode, Dictionary<int, Phrase>>();

        public static Phrase AddSpriteAnimation = new Phrase("Add Sprite Animation", "Añadir animación de Sprite");
        public static Phrase EditSpriteAnimation = new Phrase("Edit Sprite Animation", "Editar animacion de Sprite");


        public static Phrase InvalidTextField = new Phrase("{0} contains invalid characters.", "{0} contiene caracteres no válidos.");
        public static Phrase NoTextField = new Phrase("{0} needs a value.", "{0} necesita un valor.");
        
        //Sprite Object Editor
        public static Phrase AddSpriteModel = new Phrase("Add Sprite Object", "Añadir objeto Sprite");
        public static Phrase EditSpriteModel = new Phrase("Edit Sprite Object", "Editar Objeto Sprite");
        public static Phrase AddEditAnimations = new Phrase("Add/Edit Animations", "añadir/editar animaciones");

        //Project Properties
        public static Phrase EditProjectProperties = new Phrase("Edit Project Properties", "Editar propiedades del proyecto");

        //AddEditImage form
        public static Phrase ImagesFolder = new Phrase("Images Folder", "Carpeta de Imagenes");
        public static Phrase Reload = new Phrase("Reload", "Recargar");
        public static Phrase AddImage = new Phrase("Add Image", "añadir imagen");
        public static Phrase EditImage = new Phrase("Edit Image", "Editar imagen");
        public static Phrase CreateProject = new Phrase("Create Project", "Crear Proyecto");
        public static Phrase EditProject = new Phrase("Edit Project", "Editar Proyecto");
        public static Phrase Name = new Phrase("Name", "Nombre");
        public static Phrase Image = new Phrase("Image", "Imagen");
        public static Phrase Atlas = new Phrase("Atlas", "Atlante");
        public static Phrase TileSize = new Phrase("Tile Size", "Tamaño del Szulejo");
        public static Phrase Spacing = new Phrase("Spacing", "Espaciado");
        public static Phrase Margin = new Phrase("Margin", "Margen");
        public static Phrase AtlasParameters = new Phrase("Atlas Parameters", "Parámetros del Atlante");
        public static Phrase ProjectPath = new Phrase("Project Path", "Ruta del Proyecto");
        public static Phrase ImageLocation = new Phrase("Image Location", "Ubicación de la Imagen");
        public static Phrase ImageAlreadyExists = new Phrase("Image '{0}' already located in /images folder, no copy performed.", "Imagen '{0}' ya ubicada en la carpeta /imagenes. No copia realizada.");

        //Add/edit form
        public static Phrase AddItem = new Phrase("Add an item", "Añadir un artículo.");
        public static Phrase EditItem = new Phrase("Edit Selected Item", "Editar elemento seleccionado.");
        public static Phrase RemoveItem = new Phrase("Delete Selected Item", "Eliminar el elemento seleccionado");
        public static Phrase CopyItem = new Phrase("Copy Selected Item", "Copiar el elemento seleccionado");
        public static Phrase RefreshForm = new Phrase("Refresh", "Refrescar");

        //
        public static Phrase Warning = new Phrase("Warning", "Caución");
        public static Phrase RecentFiles = new Phrase("&Recent Projects", "&Proyectos Recientes");
        
        public static Phrase Ok = new Phrase("Ok", "Vale");
        public static Phrase Cancel = new Phrase("Cancel", "Cancelar");
        public static Phrase File = new Phrase("File", "Limar");
        public static Phrase Exit = new Phrase("Exit", "Salir");
        public static Phrase Language = new Phrase("Language", "Lengua");
        public static Phrase FolderDoesNotExist = new Phrase("Folder does not exist.", "La carpeta no existe.");
        public static Phrase FileDoesNotExist = new Phrase("File does not exist.", "El archivo no existe.");
        public static Phrase Options = new Phrase("Options", "Opciones");
        public static Phrase View = new Phrase("View", "Ver");
        public static Phrase Sprites = new Phrase("Sprites", "Duendes");
        public static Phrase Objects = new Phrase("Objects", "Objetos");
        public static Phrase Layers = new Phrase("Layers", "Capas");
        public static Phrase Undo = new Phrase("Undo", "Deshacer");
        public static Phrase Redo = new Phrase("Redo", "Rehacer");
        public static Phrase Edit = new Phrase("Edit", "Editar");
        public static Phrase Tools = new Phrase("Tools", "útiles");
        public static Phrase Theme = new Phrase("Theme", "Tema");
        public static Phrase Light = new Phrase("Light", "Ligero");
        public static Phrase Dark = new Phrase("Dark", "Oscuro");
        public static Phrase English = new Phrase("English", "Inglés");
        public static Phrase Spanish = new Phrase("Spanish", "Español");
        public static Phrase Error = new Phrase("Error", "Error");
        public static Phrase Info = new Phrase("Info", "Información");
        public static Phrase New = new Phrase("&New", "&Nuevo");
        public static Phrase Open = new Phrase("&Open", "&Abierto");
        public static Phrase OpenProject = new Phrase("&Open Project", "&Proyecto abierto");
        public static Phrase CloseProject = new Phrase("&Close Project", "&Cerrar proyecto");
        public static Phrase Save = new Phrase("&Save", "&Guardar");
        public static Phrase SaveAs = new Phrase("&Save As..", "&Guardar Como..");
        public static Phrase AddEdit = new Phrase("Add/Edit", "Añadir/Editar.");
        public static Phrase NewProject = new Phrase("New Project", "Nuevo Proyecto");
        public static Phrase ProjectName = new Phrase("Project Name", "Nombre Fel Proyecto");
        public static Phrase SelectFolder = new Phrase("Select Folder", "Seleccione la Carpeta");
        public static Phrase ProjectNameIsEmpty = new Phrase("Project Name Cannot Be Blank.", "El nombre del proyecto no puede estar en blanco.");
        public static Phrase ProjectFolderExists = new Phrase("Project Directory already exists.","El directorio de proyectos ya existe.");
        public static Phrase ConfirmOverwrite = new Phrase("Confirm Overwrite", "Confirmar sobreescritura");
        public static Phrase About = new Phrase("About", "Sobre");
        public static Phrase Help = new Phrase("Help", "Ayuda");
        public static Phrase PleaseCorrectTheFollowingErrors = new Phrase("Please correct the following errors: ", "Por favor corrige los siguientes errores");
        public static Phrase PathHasInvalidChars = new Phrase("Path has invalid chars", "La ruta tiene caracteres inválidos");
        public static Phrase Close = new Phrase("Close", "Cerrar");
        public static Phrase FormatCode = new Phrase("Format Code", "Código de formato");
        public static Phrase Unsaved = new Phrase("Unsaved", "No salvos");
        public static Phrase SaveProject = new Phrase("&Save Project", "&Guardar proyecto");
        public static Phrase SaveProjectAs = new Phrase("&Save Project As..", "&Guardar proyecto como..");
        public static Phrase SaveFile = new Phrase("&Save {1}", "&Guardar {1}");
        public static Phrase SaveFileAs = new Phrase("&Save {1} As..", "&Guardar {1} como..");
        public static Phrase None = new Phrase("None", "Ninguna");
        public static Phrase LoadLastProjectFile = new Phrase("Load last project file", "Cargar el último archivo de proyecto");
    }
}
