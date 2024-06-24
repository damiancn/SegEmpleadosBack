using Resources.UtilsExecptions;

namespace DataAcccess.Util
{
    public static class SqlValidation<T>
    {
        public static T VailidateFound(T? entity, string name)
        {
            if (entity == null)
            {
                throw new KeyNotFoundException($"No se localizo el registro {name}");
            }

            return entity;
        }
        public static List<T> VailidateCountList(List<T> entity, string name)
        {
            if (entity.Count == 0)
            {
                throw new KeyNotFoundException($"No se localizaron registros de {name}");
            }

            return entity;
        }
        public static void ExistRow(bool exist, string column)
        {
            if (exist)
            {
                throw new BusinessException($"El {column} ya se encuentra registrado");
            }
        }
    }
}
