
using UnityGameFramework.Runtime;
public class DRHero : DataRowBase
{
    private int m_Id = 0;

    /// <summary>
    /// 获取实体编号。
    /// </summary>
    public override int Id
    {
        get
        {
            return m_Id;
        }
    }
    private string m_Name = "";

    /// <summary>
    /// 获取实体名称。
    /// </summary>
    public string Name
    {
        get
        {
            return m_Name;
        }
    }
    private int m_Atk = 0;

    /// <summary>
    /// 获取实体编号。
    /// </summary>
    public int Atk
    {
        get
        {
            return m_Atk;
        }
    }
    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] text = dataRowString.Split('\t');

        int index = 0;
        index++; // 跳过#注释列

        m_Id = int.Parse(text[index++]);
        m_Name = text[index++];
        m_Atk = int.Parse(text[index++]);

        return true;
    }
}
