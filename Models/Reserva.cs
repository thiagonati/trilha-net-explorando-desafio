namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (hospedes == null)
                //se a suíte for nula, lança uma exceção
                throw new Exception("O número de hóspedes não pode ser nulo");

            if (hospedes.Count <= Suite.Capacidade)
            {   //se a suíte for nula, lança uma exceção
                Hospedes = hospedes;
            }
            else
            {
                //se a suíte for nula, lança uma exceção
                throw new Exception("O número de hóspedes excede a capacidade da suíte.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes != null ? Hospedes.Count : 0;
        }

        public decimal CalcularValorDiaria()
        {
            //se a suíte for nula, lança uma exceção
            if (Suite == null)
                throw new Exception("Nenhuma suíte cadastrada");

            decimal valor = DiasReservados * Suite.ValorDiaria;
            //feito o desconto
            if (DiasReservados >= 10)
            {
                valor *= 0.9m;
            }

            return valor;
        }
    }
}