using System.Text.Json;
using Domain;


namespace Repository.JsonFile
{
    public class BankRepository : IBankRepository
    {
        public void Update()
        {
            //Deserializar para um objeto a lista toda 
            // Atualizar somente o que eu tenho o Id no momento 
            // Salvar toda a coleção e não apenas um item. Modificando da lista apenas o item que tem que ser modificado. 

            // Criando o nome do arquivo com DateTime no final eu teria um "Histórico de Movimentações" a cada de input ou deleção feita no banco...
            // Ser preciso na responsabilidade de cada método. 
            // Ser preciso para não ficar muito código escrito em muitas colunas
            // Levantar requisitos até mesmo na funcionalidade, pensar demais facilita o desenvolver do problema e do mini problema. 
        }


        public void Create(BankEntity bank)
        {
            List<BankEntity> banksJson = ReadAll().ToList();
            banksJson.Add(bank);

            File.WriteAllText($"C:\\Users\\KleberM2\\Videos\\Captures\\JsonBank.json", JsonSerializer.Serialize(banksJson));
        }

        public IList<BankEntity> ReadAll()
        {

            // string jsonBanksOrigin = File.ReadAllText($"C:\\Users\\KleberM2\\Videos\\Captures\\JsonBank.json");

            // string appContext = AppContext.BaseDirectory; //"C:\\Projects\\PessoalFinancasBackend\\Api\\bin\\Debug\\net7.0\\"
            // "C:\\Projects\\JornadaDotNet_Evento\\bin\\Debug\\net7.0\\Projects.xml"
            // string app = AppDomain.CurrentDomain.BaseDirectory.ToString(); //"C:\\Projects\\PessoalFinancasBackend\\Api\\bin\\Debug\\net7.0\\"

            // string jsonBanks1 = File.ReadAllText(appContext);
            string enviroment = Environment.CurrentDirectory; // "C:\\Projects\\PessoalFinancasBackend\\Api"
            string secondTest= enviroment.Replace("Api", "Repository.JsonFile");
            
            // Mudando para Windows
            // string x = secondTest + @"\JsonBank.json";
            // Mudando para MAC
            string x = secondTest + @"/JsonBank.json";
            string jsonBanks = File.ReadAllText(x);
            // string jsonBanks3 = File.ReadAllText(app);  


            var teste = jsonBanks.Replace(@"\", "");


            // List<BankEntity> banks = JsonSerializer.Deserialize<List<BankEntity>>(teste);
            List<BankEntity> banks = JsonSerializer.Deserialize<List<BankEntity>>(jsonBanks);
            return banks;
        }

        public void Update(BankEntity id)
        {
            // Mesma coisa do Create. Porém irei atualizar e sobreescrever o arquivo
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            // Mesma coisa do Create e Update. Porém irei deletar e sobreescrever o arquivo
            throw new NotImplementedException();
        }

        public BankEntity GetById(int id) =>
            ReadAll().SingleOrDefault(x => x.Id == id);

        public int GetLastId() => 10; 

    }
}
