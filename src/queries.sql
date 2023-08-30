INSERT INTO TrybeHotel.dbo.Cities (Name)
VALUES ('Vitória');

SET IDENTITY_INSERT TrybeHotel.dbo.Rooms ON  

INSERT INTO TrybeHotel.dbo.Rooms
(RoomId, Name, Capacity, [Image], HotelId)
VALUES(1, 'Suíte Básica', 2, 'xxximagemaqui.jpeg', 1)


INSERT INTO TrybeHotel.dbo.Hotels (Name, Address, CityId)
VALUES ('Trybe Hotel', 'AV. 1', 1);