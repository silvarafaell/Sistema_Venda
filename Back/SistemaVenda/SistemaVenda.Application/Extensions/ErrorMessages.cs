namespace SistemaVenda.Application.Extensions
{
    public static class ErrorMessages
    {
        public static string IdNotFoundError() => @$"Id não encontrado";

        public static string ProductReservation() => @$"Produto já reservado";
    }
}
