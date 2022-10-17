﻿CREATE TABLE [dbo].[Nodes]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [Type] INT NOT NULL DEFAULT 0, 
    [ColourCode] INT NOT NULL, 
    [UserId] INT NOT NULL, 
    CONSTRAINT [FK_Nodes_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]),

)
