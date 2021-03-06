USE [StudentDBWindowsForm]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 9/18/2018 10:18:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Address] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([ID], [Name], [Email], [Address]) VALUES (1, N'Parvez Talukder', N'parvez@gmail.com', N'Bhuapur,Tangail')
INSERT [dbo].[Student] ([ID], [Name], [Email], [Address]) VALUES (2, N'Sumon Talukder', N'sumon@gmail.com', N'Jamuna Setu bazar')
INSERT [dbo].[Student] ([ID], [Name], [Email], [Address]) VALUES (4, N'Jibon Talukder', N'jibon@gmail.com', N'Tangail2')
SET IDENTITY_INSERT [dbo].[Student] OFF
