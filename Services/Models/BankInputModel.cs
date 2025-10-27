namespace Services.Models;

public class BankInputModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Available { get; set; }
    public int PaymentDay { get; set; }
    public string Operacao { get; set; }
    public decimal Balance { get; set; }

    public DateTime DataPagamento { get; set; }
    public List<ExtratoDto> Extratos { get; set; } = new();
    public List<ExpenseDto> Expenses { get; set; } = new List<ExpenseDto>();
    public FaturaDoBancoDto FaturaDoBanco { get; set; } = new FaturaDoBancoDto();
    public List<LancamentoDto> Lancamentos { get; set; } = new List<LancamentoDto>();
    // public void CalculateFinalBalance() =>
    //     FinalBalance = Balance - TotalExpenses;

    public void CalculaLancamento()
    {
        int iteracao = 1;
        while (iteracao <= FaturaDoBanco.TotalDeFaturas)
        {
            Lancamentos.Add
            (
                new LancamentoDto(FaturaDoBanco.MenorDataFatura, iteracao)
            );

            iteracao++;
        }
    }

    public class FaturaDoBancoDto
    {
        public FaturaDoBancoDto()
        {

        }

        public DateTime MenorDataFatura { get; set; }
        public DateTime MaiorDataFatura { get; set; }
        public int TotalDeFaturas { get; set; } // Se tiver 1 parcela com o Tipo TempoIndeterminado somar + 1 aqui com base no valor da parcela que tiver a maior data da última parcela.
        public List<FaturaDto> Faturas { get; set; } = new List<FaturaDto>();


        // Criar um switch case para esse cara
    }

    public class LancamentoDto
    {
        public LancamentoDto(DateTime menorData, int mesLancamento)
        {
            MesLancamento = mesLancamento;

            if (mesLancamento == 1)
            {
                DataLancamento =
                    DataLancamento.Replace("mes", RetornaMes(menorData.Month))
                    .Replace("ano", menorData.Year.ToString());

            }
            else
            {
                DataLancamento =
                  DataLancamento.Replace("mes", RetornaMes(menorData.AddMonths(mesLancamento - 1).Month))
                  .Replace("ano", menorData.AddMonths(mesLancamento - 1).Year.ToString());
            }
        }
        public int MesLancamento { get; set; }
        public string DataLancamento { get; set; } = "mes/ano";

        static string RetornaMes(int numeroMes)
        {
            string mes = "";

            switch (numeroMes)
            {
                case 1:
                    mes = "JAN";
                    break;
                case 2:
                    mes = "FEV";
                    break;
                case 3:
                    mes = "MAR";
                    break;
                case 4:
                    mes = "ABR";
                    break;
                case 5:
                    mes = "MAI";
                    break;
                case 6:
                    mes = "JUN";
                    break;
                case 7:
                    mes = "JUL";
                    break;
                case 8:
                    mes = "AGO";
                    break;
                case 9:
                    mes = "SET";
                    break;
                case 10:
                    mes = "OUT";
                    break;
                case 11:
                    mes = "NOV";
                    break;
                case 12:
                    mes = "DEZ";
                    break;

                default:
                    mes = "mes";
                    break;
            }

            return mes;
        }

    }
    public class FaturaDto
    {
        public FaturaDto()
        {

        }
        public int IdExpense { get; set; }
        public string Nome { get; set; }
        public int NumeroParcela { get; set; }
        public int MesLancamento { get; set; }
        public DateTime DataCompra { get; set; }
        public decimal ValorParcela { get; set; }
        public int QuantidadeTotalParcelas { get; set; }
    }
    // public List<ExpenseInputModel> Expenses { get; set; }

    // public void Calculate()
    // {

    //     // esse cara é responsável por saber o saldo final pagando tudo
    //     TotalAllExpensesRemainingActive = Expenses/*.Where(x => x.Separeted == false)*/.Sum(x => x.TotalExpenseRemaining);
    //     // esse cara é responsável por saber quanto que sobra do saldo do banco debitando todo o dinheiro separado
    //     TotalSeparetedActive = Expenses.Where(x => x.Separeted == true).Sum(x => x.TotalExpenseRemaining);

    //     // responsável por saber quanto que é debitado mensalmente.
    //     TotalMensalActive = Expenses.Where(x => x.Inactive == false).Sum(x => x.Amount);
    //     // responsável por saber a fatura do cartão de crédito
    //     Fatura = Expenses.Where(x => x.PaymentType == EPaymentType.Credito.ToString() && x.Inactive == false).Sum(x => x.Amount);

    //     // responsável por saber o total inicial sem descontar as parcelas pagas
    //     TotalAllExpensesActive = Expenses.Sum(x => x.TotalExpense);



    //     #region Calculate Total To Separeted
    //     // Total to separete Boleto
    //     // Total to separete debit card 
    //     // Total a separar crédito 
    //     TotalToSepareteCreditCardMonthly = Expenses.Where(x => x.PaymentType == EPaymentType.Credito.ToString() && x.Separeted == false &&
    //         x.Inactive == false).Sum(x => x.Amount);

    //     TotalToSepareteCreditCard = Expenses.Where(x => x.PaymentType == EPaymentType.Credito.ToString() && x.Separeted == false &&
    //         x.Inactive == false).Sum(x => x.TotalExpensesItemRemaining);

    //     // Total a pix
    //     TotalToSeparetePixMonthly = Expenses.Where(x => x.PaymentType == EPaymentType.Pix.ToString() && x.Separeted == false &&
    //         x.Inactive == false).Sum(x => x.Amount);

    //     TotalToSeparetePix = Expenses.Where(x => x.PaymentType == EPaymentType.Pix.ToString() && x.Separeted == false &&
    //         x.Inactive == false).Sum(x => x.TotalExpensesItemRemaining);

    //     TotalToSeparete = Expenses.Where(x => x.Inactive == false && x.Separeted == false).Sum(x => x.TotalExpensesItemRemaining); // esse cálculo eu posso obter somando os TotalToSeparete ao invés dessa condição, mas com essa condição é bacana que mostra que o código está calculando corretamente
    //     // TotalToSepareteMonthly
    //     #endregion

    //     #region Calculete Total Separeted
    //     // Total separeted boleto
    //     TotalSeparetedBoletoMonthly = Expenses.Where(x => x.PaymentType == EPaymentType.Boleto.ToString() && x.Separeted == true &&
    //         x.Inactive == false).Sum(x => x.Amount);

    //     TotalSeparetedBoleto = Expenses.Where(x => x.PaymentType == EPaymentType.Boleto.ToString() && x.Separeted == true &&
    //         x.Inactive == false).Sum(x => x.TotalExpensesItemRemaining);

    //     // Total separeted debito
    //     TotalSeparetedDebitMonthly = Expenses.Where(x => x.PaymentType == EPaymentType.DebitoDescontoAutomaticoPorPeriodo.ToString() && x.Separeted == true &&
    //         x.Inactive == false).Sum(x => x.Amount);

    //     TotalSeparetedDebit = Expenses.Where(x => x.PaymentType == EPaymentType.DebitoDescontoAutomaticoPorPeriodo.ToString() && x.Separeted == true &&
    //         x.Inactive == false).Sum(x => x.TotalExpensesItemRemaining);

    //     // Total separeted credit card
    //     TotalSeparetedCreditCardMonthly = Expenses.Where(x => x.PaymentType == EPaymentType.Credito.ToString() && x.Separeted == true &&
    //         x.Inactive == false).Sum(x => x.Amount);

    //     TotalSeparetedCreditCard = Expenses.Where(x => x.PaymentType == EPaymentType.Credito.ToString() && x.Separeted == true &&
    //         x.Inactive == false).Sum(x => x.TotalExpensesItemRemaining);

    //     // Total separeted pix
    //     TotalSeparetedPixMonthly = Expenses.Where(x => x.PaymentType == EPaymentType.Pix.ToString() && x.Separeted == true &&
    //         x.Inactive == false).Sum(x => x.Amount);

    //     TotalSeparetedPix = Expenses.Where(x => x.PaymentType == EPaymentType.Pix.ToString() && x.Separeted == true &&
    //         x.Inactive == false).Sum(x => x.TotalExpensesItemRemaining);

    //     // Total 
    //     TotalSepareted = CalcTotalSepareted();
    //     TotalSeparetedMonthly = CalcTotalSeparetedMonthly();
    //     #endregion

    //     SecuryBalance = Balance - TotalSepareted;
    //     FinalBalance = Balance - (TotalSepareted + TotalToSeparete);
    // }

    // public int TotalActiveExpenses { get; set; }
    // public decimal SecuryBalance { get; set; }
    // public decimal FinalBalance {get ; set; }
    // public decimal TotalAllExpensesActive { get; set; }
    // public decimal TotalAllExpensesRemainingActive { get; set; }
    // public decimal Fatura { get; set; } // só é valido para crédito
    // public decimal TotalMensalActive { get; set; }
    // public decimal TotalSeparetedActive { get; set; }
    // public decimal TotalAllCountInstallments { get; set; }
    // public decimal TotalAllCountInstallmentsRemaining { get; set; }

    // #region To Separete
    // // Total to separete Boleto 
    // public decimal TotalToSepareteBoletoMonthly { get; set; }
    // public decimal TotalToSepareteBoleto { get; set; }

    // // Total a separar Debito 
    // public decimal TotalToSepareteDebitCardMonthly { get; set; }
    // public decimal TotalToSepareteDebitCard { get; set; }

    // // Total a separar credito 
    // public decimal TotalToSepareteCreditCardMonthly { get; set; }
    // public decimal TotalToSepareteCreditCard { get; set; }

    // // Total a separar Pix 
    // public decimal TotalToSeparetePixMonthly { get; set; }
    // public decimal TotalToSeparetePix { get; set; }

    // // Real Total To Separete
    // public decimal TotalMonthly() =>
    //     TotalToSepareteCreditCardMonthly + TotalToSeparetePixMonthly;
    // public decimal TotalToSeparete { get; set; }
    // public decimal TotalToSepareteMonthly { get; set; }
    // #endregion

    // #region Total Separeted
    // // Total Separeted Boleto 
    // public decimal TotalSeparetedBoletoMonthly { get; set; }
    // public decimal TotalSeparetedBoleto { get; set; }

    // // Total Separeted Debito 
    // public decimal TotalSeparetedDebitMonthly { get; set; }
    // public decimal TotalSeparetedDebit { get; set; }

    // // Total Separeted Credit card
    // public decimal TotalSeparetedCreditCardMonthly { get; set; }
    // public decimal TotalSeparetedCreditCard { get; set; }

    // // Total Separeted Pix
    // public decimal TotalSeparetedPixMonthly { get; set; }
    // public decimal TotalSeparetedPix { get; set; }

    // // Real Total Separeted
    // public decimal TotalSeparetedMonthly { get; set; }
    // public decimal TotalSepareted { get; set; }
    // public decimal CalcTotalSeparetedMonthly() =>
    //     TotalSeparetedDebitMonthly + TotalSeparetedCreditCardMonthly + TotalSeparetedPixMonthly + TotalSeparetedBoletoMonthly;
    // public decimal CalcTotalSepareted() =>
    //     TotalSeparetedDebit + TotalSeparetedCreditCard + TotalSeparetedPix + TotalSeparetedBoleto;
    // #endregion
}