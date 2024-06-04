using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainModel.Migrations
{
    /// <inheritdoc />
    public partial class v7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConversationMessage_Conversations_ConversationId",
                table: "ConversationMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_ConversationMessage_Messages_MessageId",
                table: "ConversationMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_UserConversation_Conversations_ConversationId",
                table: "UserConversation");

            migrationBuilder.DropForeignKey(
                name: "FK_UserConversation_Users_UserId",
                table: "UserConversation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserConversation",
                table: "UserConversation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConversationMessage",
                table: "ConversationMessage");

            migrationBuilder.RenameTable(
                name: "UserConversation",
                newName: "UserConversations");

            migrationBuilder.RenameTable(
                name: "ConversationMessage",
                newName: "ConversationMessages");

            migrationBuilder.RenameIndex(
                name: "IX_UserConversation_UserId",
                table: "UserConversations",
                newName: "IX_UserConversations_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserConversation_ConversationId",
                table: "UserConversations",
                newName: "IX_UserConversations_ConversationId");

            migrationBuilder.RenameIndex(
                name: "IX_ConversationMessage_MessageId",
                table: "ConversationMessages",
                newName: "IX_ConversationMessages_MessageId");

            migrationBuilder.RenameIndex(
                name: "IX_ConversationMessage_ConversationId",
                table: "ConversationMessages",
                newName: "IX_ConversationMessages_ConversationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserConversations",
                table: "UserConversations",
                column: "UserConversationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConversationMessages",
                table: "ConversationMessages",
                column: "ConversationMessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConversationMessages_Conversations_ConversationId",
                table: "ConversationMessages",
                column: "ConversationId",
                principalTable: "Conversations",
                principalColumn: "ConversationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConversationMessages_Messages_MessageId",
                table: "ConversationMessages",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "MessageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserConversations_Conversations_ConversationId",
                table: "UserConversations",
                column: "ConversationId",
                principalTable: "Conversations",
                principalColumn: "ConversationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserConversations_Users_UserId",
                table: "UserConversations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConversationMessages_Conversations_ConversationId",
                table: "ConversationMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_ConversationMessages_Messages_MessageId",
                table: "ConversationMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserConversations_Conversations_ConversationId",
                table: "UserConversations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserConversations_Users_UserId",
                table: "UserConversations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserConversations",
                table: "UserConversations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConversationMessages",
                table: "ConversationMessages");

            migrationBuilder.RenameTable(
                name: "UserConversations",
                newName: "UserConversation");

            migrationBuilder.RenameTable(
                name: "ConversationMessages",
                newName: "ConversationMessage");

            migrationBuilder.RenameIndex(
                name: "IX_UserConversations_UserId",
                table: "UserConversation",
                newName: "IX_UserConversation_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserConversations_ConversationId",
                table: "UserConversation",
                newName: "IX_UserConversation_ConversationId");

            migrationBuilder.RenameIndex(
                name: "IX_ConversationMessages_MessageId",
                table: "ConversationMessage",
                newName: "IX_ConversationMessage_MessageId");

            migrationBuilder.RenameIndex(
                name: "IX_ConversationMessages_ConversationId",
                table: "ConversationMessage",
                newName: "IX_ConversationMessage_ConversationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserConversation",
                table: "UserConversation",
                column: "UserConversationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConversationMessage",
                table: "ConversationMessage",
                column: "ConversationMessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConversationMessage_Conversations_ConversationId",
                table: "ConversationMessage",
                column: "ConversationId",
                principalTable: "Conversations",
                principalColumn: "ConversationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConversationMessage_Messages_MessageId",
                table: "ConversationMessage",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "MessageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserConversation_Conversations_ConversationId",
                table: "UserConversation",
                column: "ConversationId",
                principalTable: "Conversations",
                principalColumn: "ConversationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserConversation_Users_UserId",
                table: "UserConversation",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
