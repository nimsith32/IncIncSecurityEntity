//WorkerContext.cs
//Author: Nimsith Fernandopulle
//Created: November 28, 2021
//Description: This is a context describing relationships related to the PieceWorkWorkerModel for which there are no relationships.
//To be used with Entity Framework.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IncIncSecurityEntity.Models;

namespace IncIncSecurityEntity.Contexts
{
    public class WorkerContext : DbContext
    {
        /// <summary>
        /// Constructor for the WorkerContext; completely uses base options
        /// </summary>
        /// <param name="options"></param>
        public WorkerContext(DbContextOptions<WorkerContext> options) : base(options)
        {

        }

        /// <summary>
        /// only entity we're descibing/using here is hourly workers.
        /// </summary>
        public DbSet<PieceWorkWorkerModel> workers { get; set; }
    }
}
