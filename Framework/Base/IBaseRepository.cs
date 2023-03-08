using Framework.BaseModel;

namespace Framework.Base
{
    public interface IBaseRepository<TModel, TKEY, TUpdateModel, TAddModel>
    {
        TModel Get(TKEY id);
        List<TModel> GetAll();
        OperationResult Remove(TKEY id);
        OperationResult Update(TUpdateModel model);
        OperationResult Add(TAddModel model);

    }
}
