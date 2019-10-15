﻿using Core.Domain.Interfaces;
using Core.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Movimentacoes.Infra.CrossCutting.IoC;
using System;
using System.Collections.Generic;

namespace Bankflix.API.Configurations
{
    public static class ConfiguracaoServicosFila
    {
        public static void ConfigurarServicosFila(this IServiceCollection services)
        {
            var comandoFilas = new List<Type>();
            comandoFilas.AddRange(BootstrapperMovimentacoes.RegistrarComandosFila());
            services.AddScoped<IQueueableService, QueueableService>(q => new QueueableService(comandoFilas));
        }
    }
}
