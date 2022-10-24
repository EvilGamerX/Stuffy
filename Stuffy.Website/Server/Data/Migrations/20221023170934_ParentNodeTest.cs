using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stuffy.Website.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class ParentNodeTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Connections_Nodes_NodeId",
                table: "Connections");

            migrationBuilder.DropIndex(
                name: "IX_Connections_NodeId",
                table: "Connections");

            migrationBuilder.DropColumn(
                name: "NodeId",
                table: "Connections");

            migrationBuilder.CreateTable(
                name: "ConnectionNode",
                columns: table => new
                {
                    ConnectionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NodesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConnectionNode", x => new { x.ConnectionsId, x.NodesId });
                    table.ForeignKey(
                        name: "FK_ConnectionNode_Connections_ConnectionsId",
                        column: x => x.ConnectionsId,
                        principalTable: "Connections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConnectionNode_Nodes_NodesId",
                        column: x => x.NodesId,
                        principalTable: "Nodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConnectionNode_NodesId",
                table: "ConnectionNode",
                column: "NodesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConnectionNode");

            migrationBuilder.AddColumn<Guid>(
                name: "NodeId",
                table: "Connections",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Connections_NodeId",
                table: "Connections",
                column: "NodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_Nodes_NodeId",
                table: "Connections",
                column: "NodeId",
                principalTable: "Nodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
