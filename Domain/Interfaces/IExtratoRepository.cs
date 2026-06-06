namespace Domain.Interfaces;

public interface IExtratoRepository : IRepository/* <ExtratoEntity> */
{
    #region RSO - Region Specific Operation
    public IEnumerable<ExtratoEntity> GetExtratosByIdBank(int idBank);
    #endregion

    #region RCO - Region Commom Operation
    #endregion

    #region CRUD Operations
    #endregion


    #region "RR.FW - REMOVE REGION.FIND WAY"
    /// <summary>
    /// Temp - To Improve. Reason: Duplicate but its works
    /// </summary>
    /// <returns></returns>
    public IEnumerable<ExtratoEntity> Read();
    #endregion
}