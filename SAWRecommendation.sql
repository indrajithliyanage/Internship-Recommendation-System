USE [IRS]
GO
/****** Object:  UserDefinedFunction [dbo].[getRecommendation]    Script Date: 11/23/2022 11:14:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER FUNCTION [dbo].[getRecommendation]
(
	@JobID INT,
	@UniID INT,
	@DegreeID INT,
	@UniYearID INT,
	@IsCompleted BIT,
	@AgeID INT,
	@Gender VARCHAR(6),
	@InternshipPeriod INT,
	@Para1W INT,
	@Para2W INT,
	@Para3W INT,
	@Para4W INT,
	@Para5W INT,
	@Para6W INT,
	@Para7W INT,
	@Para8W INT,
	@Para9W INT,
	@Para10W INT
)
RETURNS @Recommends TABLE
(
	CompanyName VARCHAR(100),
	PreferenceScore FLOAT
)
AS
BEGIN
	DECLARE @TempTable TABLE(CompanyID INT, Parameter1 FLOAT, Parameter2 FLOAT, Parameter3 FLOAT, Parameter4 FLOAT, Parameter5 FLOAT, Parameter6 FLOAT, Parameter7 FLOAT, Parameter8 FLOAT, Parameter9 FLOAT, Parameter10 FLOAT)
	
	DECLARE @AverageRate TABLE(CompanyID INT, Parameter1 FLOAT, Parameter2 FLOAT, Parameter3 FLOAT, Parameter4 FLOAT, Parameter5 FLOAT, Parameter6 FLOAT, Parameter7 FLOAT, Parameter8 FLOAT, Parameter9 FLOAT, Parameter10 FLOAT)

	INSERT INTO @TempTable VALUES(0,@Para1W,@Para2W,@Para3W,@Para4W,@Para5W,@Para6W,@Para7W,@Para8W,@Para9W,@Para10W)

	INSERT INTO @TempTable 
	SELECT CompanyID, Parameter1, Parameter2, Parameter3, Parameter4, Parameter5, Parameter6, Parameter7, Parameter8, Parameter9, Parameter10 
	FROM ApprovedIE
	WHERE JobID = IIF(ISNULL(@JobID, '') = '', JobID, @JobID) AND 
	UniID = IIF(ISNULL(@UniID, '') = '', UniID, @UniID) AND 
	DegreeID = IIF(ISNULL(@DegreeID, '') = '', DegreeID, @DegreeID) AND 
	UniYearID = IIF(ISNULL(@UniYearID, '') = '',UniYearID , @UniYearID) AND 
	IsCompleted = IIF(ISNULL(@IsCompleted, '') = '', IsCompleted , @IsCompleted) AND 
	AgeID = IIF(ISNULL(@AgeID, '') = '', AgeID , @AgeID) AND 
	Gender = IIF(ISNULL(@Gender, '') = '', Gender , @Gender) AND 
	InternshipPeriod = IIF(ISNULL(@InternshipPeriod, '') = '', InternshipPeriod , @InternshipPeriod)

	INSERT INTO @AverageRate 
	SELECT CompanyID, AVG(Cast(Parameter1 AS FLOAT)), AVG(Cast(Parameter2 AS FLOAT)), AVG(Cast(Parameter3 AS FLOAT)), AVG(Cast(Parameter4 AS FLOAT)), AVG(Cast(Parameter5 AS FLOAT)), AVG(Cast(Parameter6 AS FLOAT)), AVG(Cast(Parameter7 AS FLOAT)), AVG(Cast(Parameter8 AS FLOAT)), AVG(Cast(Parameter9 AS FLOAT)), AVG(Cast(Parameter10 AS FLOAT)) 
	FROM @TempTable	
	GROUP BY CompanyID

	DECLARE @Para1Sum FLOAT;
	SET @Para1Sum = (SELECT SUM(Parameter1) FROM @AverageRate)
	DECLARE @Para2Sum FLOAT;
	SET @Para2Sum = (SELECT SUM(Parameter2) FROM @AverageRate)
	DECLARE @Para3Sum FLOAT;
	SET @Para3Sum = (SELECT SUM(Parameter3) FROM @AverageRate)
	DECLARE @Para4Sum FLOAT;
	SET @Para4Sum = (SELECT SUM(Parameter4) FROM @AverageRate)
	DECLARE @Para5Sum FLOAT;
	SET @Para5Sum = (SELECT SUM(Parameter5) FROM @AverageRate)
	DECLARE @Para6Sum FLOAT;
	SET @Para6Sum = (SELECT SUM(Parameter6) FROM @AverageRate)
	DECLARE @Para7Sum FLOAT;
	SET @Para7Sum = (SELECT SUM(Parameter7) FROM @AverageRate)
	DECLARE @Para8Sum FLOAT;
	SET @Para8Sum = (SELECT SUM(Parameter8) FROM @AverageRate)
	DECLARE @Para9Sum FLOAT;
	SET @Para9Sum = (SELECT SUM(Parameter9) FROM @AverageRate)
	DECLARE @Para10Sum FLOAT;
	SET @Para10Sum = (SELECT SUM(Parameter10) FROM @AverageRate)

	DECLARE @NMatrix TABLE(CompanyID INT , Parameter1 FLOAT, Parameter2 FLOAT, Parameter3 FLOAT, Parameter4 FLOAT, Parameter5 FLOAT, Parameter6 FLOAT, Parameter7 FLOAT, Parameter8 FLOAT, Parameter9 FLOAT, Parameter10 FLOAT)
	INSERT INTO @NMatrix SELECT CompanyID, Parameter1/@Para1Sum, Parameter2/@Para2Sum, Parameter3/@Para3Sum, Parameter4/@Para4Sum, Parameter5/@Para5Sum, Parameter6/@Para6Sum, Parameter7/@Para7Sum, Parameter8/@Para8Sum, Parameter9/@Para9Sum, Parameter10/@Para10Sum FROM @AverageRate
	
	DECLARE @GlobalPScore TABLE(CompanyID INT, PreferenceScore FLOAT)
	INSERT INTO @GlobalPScore (CompanyID, PreferenceScore)
	SELECT CompanyID, (Parameter1 * 0.06993 + Parameter2 * 0.05386 + Parameter3 * 0.06493 + Parameter4 * 0.14407 + Parameter5 * 0.08189 + Parameter6 * 0.05261 + Parameter7 * 0.09434 + Parameter8 * 0.17255 + Parameter9 * 0.13712 + Parameter10 * 0.1287) 
	FROM @Nmatrix	

	--INSERT INTO @Recommends(CompanyName,PreferenceScore) 
	--SELECT * FROM @GlobalPScore WHERE PreferenceScore > (SELECT PreferenceScore FROM @GlobalPScore WHERE CompanyID = 0)

	INSERT INTO @Recommends(CompanyName,PreferenceScore) 
	SELECT Company.CompanyName,[@GlobalPScore].PreferenceScore FROM Company 
	INNER JOIN @GlobalPScore
	ON Company.CompanyID = [@GlobalPScore].CompanyID
		
	RETURN 
END
