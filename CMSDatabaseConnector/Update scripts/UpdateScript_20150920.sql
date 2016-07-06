-- Creating table 'Log'
CREATE TABLE [dbo].[Log] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Message] nvarchar(max)  NOT NULL
);

-- Creating primary key on [Id] in table 'Log'
ALTER TABLE [dbo].[Log]
ADD CONSTRAINT [PK_Log]
    PRIMARY KEY CLUSTERED ([Id] ASC);
