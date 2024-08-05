USE [ERS]
GO

-- Insert records into Attendee table
INSERT INTO [ERS].[Attendee] (Name, Email) VALUES 
('John Doe', 'johndoe@example.com'),
('Jane Smith', 'janesmith@example.com'),
('Alice Johnson', 'alice.johnson@example.com'),
('Robert Brown', 'robert.brown@example.com'),
('Emily Davis', 'emily.davis@example.com');

-- Insert records into Event table
INSERT INTO [ERS].[Event] (Name, Description, StartDate, EndDate, Location, Organizer) VALUES 
('Future Vision Conference', 'A conference about future technologies and innovations.', '2023-05-01 09:00:00', '2023-05-02 17:00:00', 'New York', 'Tech Innovators Inc.'),
('Global Health Summit', 'Discussing the global health challenges and solutions.', '2023-06-10 10:00:00', '2023-06-11 16:00:00', 'Los Angeles', 'Health World Organization'),
('Climate Action Forum', 'Focusing on climate change and environmental protection.', '2023-07-15 09:30:00', '2023-07-16 17:30:00', 'San Francisco', 'Green Earth Foundation'),
('AI & Robotics Expo', 'Showcasing the latest in AI and robotics technology.', '2023-08-20 08:00:00', '2023-08-21 18:00:00', 'Boston', 'Robotics Corp.'),
('Digital Transformation Workshop', 'A workshop on digital transformation strategies for businesses.', '2023-09-25 09:00:00', '2023-09-26 17:00:00', 'Chicago', 'Digital Solutions Ltd.');

-- Insert records into Registration table
INSERT INTO [ERS].[Registration] (EventId, AttendeeId, AttendanceDate, RegistrationDate) VALUES 
(2, 1, NULL, '2023-05-01 13:39:14'), 
(4, 2, '2024-07-21 06:20:46', '2023-10-11 18:07:16'), 
(2, 3, NULL, '2023-06-02 09:45:14'), 
(3, 4, '2024-05-26 03:16:24', '2023-07-27 23:04:58'), 
(3, 5, '2023-08-23 08:46:38', '2023-08-22 11:49:58');


-- Insert sample data into the tables
--INSERT INTO [ERS].[Attendee] ([Name], [Email]) VALUES ('Alice Johnson', 'alice.johnson@email.com');
--GO
--INSERT INTO [ERS].[Attendee] ([Name], [Email]) VALUES ('Bob Brown', 'bob.brown@email.com');
--GO
--INSERT INTO [ERS].[Attendee] ([Name], [Email]) VALUES ('Carol White', 'carol.white@email.com');
--GO
--INSERT INTO [ERS].[Attendee] ([Name], [Email]) VALUES ('Dave Green', 'dave.green@email.com');
--GO
--INSERT INTO [ERS].[Attendee] ([Name], [Email]) VALUES ('Eve Black', 'eve.black@email.com');
--GO

--INSERT INTO [ERS].[Event] ([Name], [Description], [StartDate], [EndDate], [Location], [Organizer]) VALUES ('Tech Innovators Summit', 'A summit showcasing the latest innovations in technology.', '2021-04-15', '2021-04-17', 'San Francisco, CA', 'Tech World Inc.');
--GO
--INSERT INTO [ERS].[Event] ([Name], [Description], [StartDate], [EndDate], [Location], [Organizer]) VALUES ('Health and Wellness Expo', 'An expo focused on promoting health and wellness.', '2021-05-10', '2021-05-12', 'Los Angeles, CA', 'Wellness Corp.');
--GO
--INSERT INTO [ERS].[Event] ([Name], [Description], [StartDate], [EndDate], [Location], [Organizer]) VALUES ('Sustainable Energy Conference', 'A conference discussing sustainable energy solutions.', '2021-06-20', '2021-06-22', 'New York, NY', 'Green Energy Solutions');
--GO
--INSERT INTO [ERS].[Event] ([Name], [Description], [StartDate], [EndDate], [Location], [Organizer]) VALUES ('Digital Marketing Workshop', 'A workshop on the latest digital marketing strategies.', '2021-07-05', '2021-07-06', 'Chicago, IL', 'Marketing Gurus');
--GO
--INSERT INTO [ERS].[Event] ([Name], [Description], [StartDate], [EndDate], [Location], [Organizer]) VALUES ('AI and Machine Learning Conference', 'A conference exploring AI and machine learning advancements.', '2021-08-15', '2021-08-17', 'Boston, MA', 'AI Future Labs');
--GO

--INSERT INTO [ERS].[Registration] ([EventId], [AttendeeId], [RegistrationDate], [AttendanceDate]) VALUES (3, 3, '2021-03-01', NULL);
--GO
--INSERT INTO [ERS].[Registration] ([EventId], [AttendeeId], [RegistrationDate], [AttendanceDate]) VALUES (3, 4, '2021-03-01', NULL);
--GO
--INSERT INTO [ERS].[Registration] ([EventId], [AttendeeId], [RegistrationDate], [AttendanceDate]) VALUES (4, 1, '2021-04-01', NULL);
--GO
--INSERT INTO [ERS].[Registration] ([EventId], [AttendeeId], [RegistrationDate], [AttendanceDate]) VALUES (5, 2, '2021-05-01', NULL);
--GO
--INSERT INTO [ERS].[Registration] ([EventId], [AttendeeId], [RegistrationDate], [AttendanceDate]) VALUES (1, 5, '2021-06-01', NULL);
--GO