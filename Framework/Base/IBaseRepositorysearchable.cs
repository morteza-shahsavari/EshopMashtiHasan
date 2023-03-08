

namespace Framework.Base
{
    public interface IBaseRepositorysearchable<TModel, TKEY, TSearchModel, TlistItem, TUpdateModel, TAddModel> : IBaseRepository<TModel, TKEY, TUpdateModel, TAddModel>
    {
        List<TlistItem> Search(TSearchModel sm, out int RecordCount);

    }
}
