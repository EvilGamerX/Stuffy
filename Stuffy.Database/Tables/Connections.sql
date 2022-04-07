CREATE TABLE [dbo].[Connections]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Relationship] NVARCHAR(MAX) NOT NULL, 
    [Colour] INT NOT NULL, 
    [OtherNodeId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_Connections_OtherNodes] FOREIGN KEY ([OtherNodeId]) REFERENCES [Nodes]([Id])
)
