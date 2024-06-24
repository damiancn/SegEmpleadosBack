namespace Dtos.Commons
{
    public class ResponseDto<T>
    {
        public string Mesage { get; set; }
        public string MesageError { get; set; }
        public bool Ok { get; set; }
        public T Dto { get; set; }
    }
}
