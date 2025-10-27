namespace Services;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TInputModel"></typeparam>
/// <typeparam name="TDto"></typeparam>
/// <typeparam name="TEntity"></typeparam>
/// <typeparam name="TEntityData"></typeparam>
public interface IService<TInputModel, TDto, TEntity, TEntityData>
{
    #region CRUD OPERATION
    TDto Create(TInputModel input);
    List<TDto> Read(bool inactived = false);
    TDto Update(TInputModel dto);
    bool Delete(TInputModel input);

    #endregion

    #region COMMOM OPERATIONS 
    public TDto GetById(int id);

    #endregion

    #region REMOVER 
    // bool Create(TInputModel input, bool remover = true);
    // bool Update(TInputModel input, bool remover = true);
    // TDto GetById(int id, bool remover = true);

    // [Obsolete("Depreciado.")]
    // TEntity MappingInputModelToEntity(TInputModel input);

    // /// <summary>
    // /// Usado para operações de inserção. (Create, Update, Patch...)
    // /// </summary>
    // /// <param name="obj">Entidade do domínio</param>
    // /// <returns>Objeto do repositório TEntityData</returns>
    // List<TEntityData> MappingListEntityToListEntityData(List<TEntity> entities);

    #endregion

}