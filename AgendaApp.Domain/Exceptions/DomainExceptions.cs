using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Exceptions;

/// <summary>
/// Classe de captura de exceções para o domínio
/// </summary>
public class DomainExceptions : Exception
{
    public DomainExceptions(string errorMessage)
        : base(errorMessage)
    {
        
    }

    public static void When(bool hasError, string errorMessage)
    {
        if(hasError) { 
            throw new DomainExceptions(errorMessage);
        }
    }
}
