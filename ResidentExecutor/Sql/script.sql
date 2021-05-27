CREATE TABLE Measurment (
    Id int IDENTITY(1,1) PRIMARY KEY,
    MeasurmentValue float,
    MeasurmentDate  DateTime2,
    AreaName varchar(255),
	AreaCode varchar(255),
);

CREATE TABLE Calculation (
    Id int IDENTITY(1,1) PRIMARY KEY,
    Calc1 float,
	Calc2 float,
	Calc3 float,
    CalculationDate  DateTime2,
);