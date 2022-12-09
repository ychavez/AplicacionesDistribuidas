namespace Ordering.Infraestructure
{
    public static class StringExtensions
    {
        /// <summary>
        /// Esta extension nos agrega el saludo al string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string AgregarSaludo(this string str,DateTime date)
            =>$"hola {str}";

    }
}
