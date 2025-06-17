namespace MVCAppCRUDRazorCodeFirst.Models
{
    public class Atletlas
    {
        // AQUI TAMBIEN SE PUEDE CONFIGURAR CADA COLUMNA (KEY,INCREMENT,LENGTH,ETC) PERO SE USA UNA CLASE PARA ESTO.

        public int IdAtleta {  get; set; }

        public string AtletaName { get; set; }

        public string AtletaType { get; set; }

        public DateOnly FechaContrato { get;set; }

        public bool Activo { get; set; }

    }
}
