Feature: CreatePaymentDetails
	As a user i need an option to create new Payment Details using Web UI

@US-001 @Test-001-01
Scenario: Enter valid Payment details and submit
	When user enters in Create Payment form:
		| CardOwnerName | CardNumber		| ExpirationDate	| CVV |
		| John Doe		| 1234123412341234	| 11/44				| 123 |
	Then button Submit is enabled in Create Payment form
	When user clicks button Submit in Create Payment form
	Then Payment Details service is called with POST request
	Then the following Payment Detail is asked to be created:
		| CardOwnerName | CardNumber		| ExpirationDate	| CVV |
		| John Doe		| 1234123412341234	| 11/44				| 123 |
	
	