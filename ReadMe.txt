
Before execute the application,Please follow the below steps

1) Open the solution in Visual studio 2012 or latter IDE.
2) Update all the nuget package reference .
3) Wonga.Airlines - set as the startup project (Console application).

INPUT SETUP:

4) Open the "InputFile" folder in the Wonga.Airlines  project.
5) Open the "InputFile_FlightInputInformation.txt" file from the above folder.
6) Add the  test data in the text file as per the given format
    Example :
	        add route London Dublin 100 150 75
			add aircraft Gulfstream-G550 12
			add general Mark 35
			add general Tom 15
			add general James 72
			add general Jack 50
			add airline Jane 75
			add general Steve 20

OUTPUT RESULT:
7)Once successfully executes the console app
8) Open the "OutputFile_FlightSummaryInformation.txt" file under the "OutputFile" folder in " Wonga.Airlines" project
Example :
         6 5 1 0 6 0 600 900 750 FALSE
