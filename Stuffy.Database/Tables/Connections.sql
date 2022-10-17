CREATE TABLE [dbo].[Connections]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Relationship] NVARCHAR(MAX) NOT NULL, 
    [ColourCode] INT NOT NULL, 
    [ParentId] UNIQUEIDENTIFIER NOT NULL, 
    [NodeId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_Connections_OtherNodes] FOREIGN KEY ([NodeId]) REFERENCES [Nodes]([Id])
)
