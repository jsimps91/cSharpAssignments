using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using project.Models;

namespace project.Migrations
{
    [DbContext(typeof(PizzaContext))]
    [Migration("20180122211228_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("project.Models.Pizza", b =>
                {
                    b.Property<int>("PizzaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Topping");

                    b.Property<string>("Type");

                    b.HasKey("PizzaId");

                    b.ToTable("Pizzas");
                });
        }
    }
}
