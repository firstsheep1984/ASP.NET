CREATE TABLE [dbo].[MembershipTypes] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (255) NOT NULL,
    [SingUpfee]        INT            NOT NULL,
    [DurationInMonths] INT            NOT NULL,
    [DiscountRate]     TINYINT        NOT NULL,
    CONSTRAINT [PK_dbo.MembershipTypes] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.MembershipTypes_dbo.Customers_Customer_Id] FOREIGN KEY ([Customer_Id]) REFERENCES [dbo].[Customers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Customer_Id]
    ON [dbo].[MembershipTypes]([Customer_Id] ASC);

