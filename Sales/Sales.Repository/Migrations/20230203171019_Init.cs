using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Sales.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_categoria_produto",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    criadoem = table.Column<DateTime>(name: "criado_em", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_categoria_produto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_cidade",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    uf = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    criadoem = table.Column<DateTime>(name: "criado_em", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cidade", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_imagem",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    nomearquivo = table.Column<string>(name: "nome_arquivo", type: "character varying(20)", maxLength: 20, nullable: false),
                    principal = table.Column<bool>(type: "boolean", nullable: false),
                    criadoem = table.Column<DateTime>(name: "criado_em", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_imagem", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_produto",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    codigo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    preco = table.Column<decimal>(type: "numeric(17,2)", precision: 17, scale: 2, nullable: false),
                    idcategoria = table.Column<int>(name: "id_categoria", type: "integer", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    criadoem = table.Column<DateTime>(name: "criado_em", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_produto", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_produto_tb_categoria_produto_id_categoria",
                        column: x => x.idcategoria,
                        principalTable: "tb_categoria_produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_endereco",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipo = table.Column<byte>(type: "smallint", nullable: false),
                    logradouro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    bairro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    numero = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    complemento = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    cep = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    idcidade = table.Column<int>(name: "id_cidade", type: "integer", nullable: false),
                    criadoem = table.Column<DateTime>(name: "criado_em", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_endereco", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_endereco_tb_cidade_id_cidade",
                        column: x => x.idcidade,
                        principalTable: "tb_cidade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_combo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    preco = table.Column<decimal>(type: "numeric(17,2)", precision: 17, scale: 2, nullable: false),
                    idimagem = table.Column<int>(name: "id_imagem", type: "integer", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    criadoem = table.Column<DateTime>(name: "criado_em", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_combo", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_combo_tb_imagem_id_imagem",
                        column: x => x.idimagem,
                        principalTable: "tb_imagem",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_imagem_produto",
                columns: table => new
                {
                    idimagem = table.Column<int>(name: "id_imagem", type: "integer", nullable: false),
                    idproduto = table.Column<int>(name: "id_produto", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_imagem_produto", x => new { x.idimagem, x.idproduto });
                    table.ForeignKey(
                        name: "FK_tb_imagem_produto_tb_imagem_id_imagem",
                        column: x => x.idimagem,
                        principalTable: "tb_imagem",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_imagem_produto_tb_produto_id_produto",
                        column: x => x.idproduto,
                        principalTable: "tb_produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_promocao_produto",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    preco = table.Column<decimal>(type: "numeric(17,2)", precision: 17, scale: 2, nullable: false),
                    idimagem = table.Column<int>(name: "id_imagem", type: "integer", nullable: false),
                    idproduto = table.Column<int>(name: "id_produto", type: "integer", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    criadoem = table.Column<DateTime>(name: "criado_em", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_promocao_produto", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_promocao_produto_tb_imagem_id_imagem",
                        column: x => x.idimagem,
                        principalTable: "tb_imagem",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_promocao_produto_tb_produto_id_produto",
                        column: x => x.idproduto,
                        principalTable: "tb_produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    idendereco = table.Column<int>(name: "id_endereco", type: "integer", nullable: false),
                    criadoem = table.Column<DateTime>(name: "criado_em", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cliente", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_cliente_tb_endereco_id_endereco",
                        column: x => x.idendereco,
                        principalTable: "tb_endereco",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_produto_combo",
                columns: table => new
                {
                    idproduto = table.Column<int>(name: "id_produto", type: "integer", nullable: false),
                    idcombo = table.Column<int>(name: "id_combo", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_produto_combo", x => new { x.idproduto, x.idcombo });
                    table.ForeignKey(
                        name: "FK_tb_produto_combo_tb_combo_id_combo",
                        column: x => x.idcombo,
                        principalTable: "tb_combo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_produto_combo_tb_produto_id_produto",
                        column: x => x.idproduto,
                        principalTable: "tb_produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_pedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    numero = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    valortotal = table.Column<decimal>(name: "valor_total", type: "numeric(17,2)", precision: 17, scale: 2, nullable: false),
                    entrega = table.Column<TimeSpan>(type: "interval", nullable: false),
                    idcliente = table.Column<int>(name: "id_cliente", type: "integer", nullable: false),
                    criadoem = table.Column<DateTime>(name: "criado_em", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_pedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_pedido_tb_cliente_id_cliente",
                        column: x => x.idcliente,
                        principalTable: "tb_cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_produto_pedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantidade = table.Column<int>(type: "integer", precision: 2, nullable: false),
                    preco = table.Column<decimal>(type: "numeric(17,2)", precision: 17, scale: 2, nullable: false),
                    idproduto = table.Column<int>(name: "id_produto", type: "integer", nullable: false),
                    idpedido = table.Column<int>(name: "id_pedido", type: "integer", nullable: false),
                    criadoem = table.Column<DateTime>(name: "criado_em", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_produto_pedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_produto_pedido_tb_pedido_id_pedido",
                        column: x => x.idpedido,
                        principalTable: "tb_pedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_produto_pedido_tb_produto_id_produto",
                        column: x => x.idproduto,
                        principalTable: "tb_produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_cliente_id_endereco",
                table: "tb_cliente",
                column: "id_endereco",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_combo_id_imagem",
                table: "tb_combo",
                column: "id_imagem");

            migrationBuilder.CreateIndex(
                name: "IX_tb_endereco_id_cidade",
                table: "tb_endereco",
                column: "id_cidade");

            migrationBuilder.CreateIndex(
                name: "IX_tb_imagem_produto_id_produto",
                table: "tb_imagem_produto",
                column: "id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_tb_pedido_id_cliente",
                table: "tb_pedido",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_tb_produto_id_categoria",
                table: "tb_produto",
                column: "id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_tb_produto_combo_id_combo",
                table: "tb_produto_combo",
                column: "id_combo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_produto_pedido_id_pedido",
                table: "tb_produto_pedido",
                column: "id_pedido");

            migrationBuilder.CreateIndex(
                name: "IX_tb_produto_pedido_id_produto",
                table: "tb_produto_pedido",
                column: "id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_tb_promocao_produto_id_imagem",
                table: "tb_promocao_produto",
                column: "id_imagem");

            migrationBuilder.CreateIndex(
                name: "IX_tb_promocao_produto_id_produto",
                table: "tb_promocao_produto",
                column: "id_produto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_imagem_produto");

            migrationBuilder.DropTable(
                name: "tb_produto_combo");

            migrationBuilder.DropTable(
                name: "tb_produto_pedido");

            migrationBuilder.DropTable(
                name: "tb_promocao_produto");

            migrationBuilder.DropTable(
                name: "tb_combo");

            migrationBuilder.DropTable(
                name: "tb_pedido");

            migrationBuilder.DropTable(
                name: "tb_produto");

            migrationBuilder.DropTable(
                name: "tb_imagem");

            migrationBuilder.DropTable(
                name: "tb_cliente");

            migrationBuilder.DropTable(
                name: "tb_categoria_produto");

            migrationBuilder.DropTable(
                name: "tb_endereco");

            migrationBuilder.DropTable(
                name: "tb_cidade");
        }
    }
}
