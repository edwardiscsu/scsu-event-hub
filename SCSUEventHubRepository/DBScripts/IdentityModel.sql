-- Script Date: 4/15/2015 8:36 PM  - ErikEJ.SqlCeScripting version 3.5.2.39
CREATE TABLE [AspNetUsers] (
  [Id] nvarchar(4000) NOT NULL
, [UserName] nvarchar(4000) NULL
, [PasswordHash] nvarchar(4000) NULL
, [SecurityStamp] nvarchar(4000) NULL
, [Email] nvarchar(4000) NULL
, [Discriminator] nvarchar(128) NOT NULL
);
GO
ALTER TABLE [AspNetUsers] ADD CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY ([Id]);
GO

-- Script Date: 4/15/2015 8:23 PM  - ErikEJ.SqlCeScripting version 3.5.2.39
CREATE TABLE [AspNetRoles] (
  [Id] nvarchar(4000) NOT NULL
, [Name] nvarchar(4000) NOT NULL
);
GO
ALTER TABLE [AspNetRoles] ADD CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY ([Id]);
GO

-- Script Date: 4/15/2015 8:36 PM  - ErikEJ.SqlCeScripting version 3.5.2.39
CREATE TABLE [AspNetUserRoles] (
  [UserId] nvarchar(4000) NOT NULL
, [RoleId] nvarchar(4000) NOT NULL
);
GO
ALTER TABLE [AspNetUserRoles] ADD CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY ([UserId],[RoleId]);
GO
CREATE INDEX [IX_RoleId] ON [AspNetUserRoles] ([RoleId] ASC);
GO
CREATE INDEX [IX_UserId] ON [AspNetUserRoles] ([UserId] ASC);
GO
ALTER TABLE [AspNetUserRoles] ADD CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles]([Id]) ON DELETE CASCADE ON UPDATE NO ACTION;
GO
ALTER TABLE [AspNetUserRoles] ADD CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers]([Id]) ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Script Date: 4/15/2015 8:36 PM  - ErikEJ.SqlCeScripting version 3.5.2.39
CREATE TABLE [AspNetUserLogins] (
  [UserId] nvarchar(4000) NOT NULL
, [LoginProvider] nvarchar(4000) NOT NULL
, [ProviderKey] nvarchar(4000) NOT NULL
);
GO
ALTER TABLE [AspNetUserLogins] ADD CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY ([UserId],[LoginProvider],[ProviderKey]);
GO
CREATE INDEX [IX_UserId] ON [AspNetUserLogins] ([UserId] ASC);
GO
ALTER TABLE [AspNetUserLogins] ADD CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers]([Id]) ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Script Date: 4/15/2015 8:36 PM  - ErikEJ.SqlCeScripting version 3.5.2.39
CREATE TABLE [AspNetUserClaims] (
  [Id] int IDENTITY (1,1) NOT NULL
, [ClaimType] nvarchar(4000) NULL
, [ClaimValue] nvarchar(4000) NULL
, [User_Id] nvarchar(4000) NOT NULL
);
GO
ALTER TABLE [AspNetUserClaims] ADD CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY ([Id]);
GO
CREATE INDEX [IX_User_Id] ON [AspNetUserClaims] ([User_Id] ASC);
GO
ALTER TABLE [AspNetUserClaims] ADD CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_User_Id] FOREIGN KEY ([User_Id]) REFERENCES [AspNetUsers]([Id]) ON DELETE CASCADE ON UPDATE NO ACTION;
GO

