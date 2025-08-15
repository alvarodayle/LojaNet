using LojaNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LojaNet.Services
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da interface "IConsultaCliente" no arquivo de código e configuração ao mesmo tempo.
    [ServiceContract]
    public interface IConsultaCliente
    {
        [OperationContract]
        ClienteInfo ConsultaPorEmail(string chave, string email);
    }
}
