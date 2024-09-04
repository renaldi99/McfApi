CREATE DATABASE SQL_MCF;

CREATE TABLE ms_storage_location (
	location_id int IDENTITY(1,1) NOT NULL,
	location_name varchar(100) NULL,
	CONSTRAINT PK_ms_storage_location PRIMARY KEY (location_id)
);

CREATE TABLE dbo.ms_user (
	user_id int IDENTITY(1,1) NOT NULL,
	user_name varchar(20) NULL,
	password varchar(50) NULL,
	is_active bit NULL,
	CONSTRAINT PK_ms_user PRIMARY KEY (user_id)
);

CREATE TABLE dbo.tr_bpkb (
	agreement_number int IDENTITY(1,1) NOT NULL,
	bpkb_no varchar(100) NULL,
	branch_id varchar(10) NULL,
	bpkb_date datetime2 NULL,
	faktur_no varchar(100) NULL,
	faktur_date datetime2 NULL,
	location_id int NOT NULL,
	police_no varchar(20) NULL,
	bpkb_date_in datetime2 NULL,
	created_by varchar(20) NULL,
	created_on datetime2 NULL,
	last_updated_by varchar(20) NULL,
	last_updated_on datetime2 NULL,
	CONSTRAINT PK_tr_bpkb PRIMARY KEY (agreement_number),
	CONSTRAINT FK_tr_bpkb_ms_storage_location_location_id FOREIGN KEY (location_id) REFERENCES ms_storage_location(location_id) ON DELETE CASCADE
);

