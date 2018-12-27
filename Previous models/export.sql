--------------------------------------------------------
--  File created - Wednesday-December-12-2018   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Sequence EID_INCREMENT
--------------------------------------------------------
-- NO Sequence is not used in the database
   --CREATE SEQUENCE  "EID_INCREMENT"  MINVALUE 1 MAXVALUE 10000 INCREMENT BY 1 START WITH 21 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Table ALLOWANCE
--------------------------------------------------------

  CREATE TABLE "ALLOWANCE" 
   (	"POST" VARCHAR2(20), 
	"WOH" NUMBER, 
	"WONS" NUMBER, 
	"MEAL_ALLOWANCE" NUMBER, 
	"AID" NUMBER(*,0), 
	"WOSH" NUMBER
   ) ;
--------------------------------------------------------
--  DDL for Table ATTENDANCE
--------------------------------------------------------

  CREATE TABLE "ATTENDANCE" 
   (	"AID" NUMBER(*,0), 
	"EID" NUMBER(*,0), 
	"ATTEND_DATE" DATE, 
	"LOGIN_TIME" TIMESTAMP (6), 
	"LOGOUT_TIME" TIMESTAMP (6), 
	"SHIFT" VARCHAR2(15), 
	"TOTAL_TIME" TIMESTAMP (6), 
	"LOGOUT_DATE" TIMESTAMP (6)
   ) ;
--------------------------------------------------------
--  DDL for Table ATTENDANCE_CLAIM
--------------------------------------------------------

  CREATE TABLE "ATTENDANCE_CLAIM" 
   (	"CAID" NUMBER, 
	"EID" NUMBER, 
	"LOGIN_DATE" DATE, 
	"LOGIN_TIME" TIMESTAMP (6), 
	"LOGOUT_DATE" DATE, 
	"LOGOUT_TIME" TIMESTAMP (6), 
	"REASON" VARCHAR2(50), 
	"STATUS" VARCHAR2(20)
   ) ;
--------------------------------------------------------
--  DDL for Table EMPLOYEE
--------------------------------------------------------

  CREATE TABLE "EMPLOYEE" 
   (	"EID" NUMBER(*,0), 
	"FULL_NAME" VARCHAR2(30), 
	"ADDRESS" VARCHAR2(50), 
	"GENDER" CHAR(1), 
	"EMAIL" VARCHAR2(50), 
	"PASSCODE" VARCHAR2(30), 
	"CONTACT" LONG
   ) ;
--------------------------------------------------------
--  DDL for Table EMPLOYEE_POST
--------------------------------------------------------

  CREATE TABLE "EMPLOYEE_POST" 
   (	"EPOID" NUMBER(*,0), 
	"EID" NUMBER(*,0), 
	"POST" VARCHAR2(20)
   ) ;
--------------------------------------------------------
--  DDL for Table HOLIDAY_LIST
--------------------------------------------------------

  CREATE TABLE "HOLIDAY_LIST" 
   (	"HID" NUMBER(*,0), 
	"H_DATE" DATE, 
	"OCCATION" VARCHAR2(30)
   ) ;
--------------------------------------------------------
--  DDL for Table LEAVE
--------------------------------------------------------

  CREATE TABLE "LEAVE" 
   (	"LID" NUMBER(*,0), 
	"EID" NUMBER(*,0), 
	"LEAVE_TYPE" VARCHAR2(15), 
	"FROM_DATE" DATE, 
	"TO_DATE" DATE, 
	"DAYS" NUMBER(*,0), 
	"REASON" VARCHAR2(150), 
	"STATUS" VARCHAR2(20)
   ) ;
--------------------------------------------------------
--  DDL for Table LEAVEDAYS
--------------------------------------------------------

  CREATE TABLE "LEAVEDAYS" 
   (	"LDID" NUMBER, 
	"EID" NUMBER, 
	"LEAVETYPE" VARCHAR2(20), 
	"DAYS" NUMBER
   ) ;
--------------------------------------------------------
--  DDL for Table LEAVES_TYPES
--------------------------------------------------------

  CREATE TABLE "LEAVES_TYPES" 
   (	"LTID" NUMBER, 
	"LEAVE_NAME" VARCHAR2(20), 
	"DAYS_OFF" NUMBER
   ) ;
--------------------------------------------------------
--  DDL for Table MONTHLY_STATEMENT
--------------------------------------------------------

  CREATE TABLE "MONTHLY_STATEMENT" 
   (	"MON_REC_ID" NUMBER, 
	"EID" NUMBER, 
	"MONTH" VARCHAR2(20), 
	"TOTALLEAVEDAYS" NUMBER, 
	"TOTALWORKINGHRS" NUMBER, 
	"TOTALNIGHTSHIFTS" NUMBER, 
	"TOTALWOH" NUMBER, 
	"TOTALWOSH" NUMBER, 
	"TOTALMEALALLOW" NUMBER
   ) ;
--------------------------------------------------------
--  DDL for Table PAYOUT
--------------------------------------------------------

  CREATE TABLE "PAYOUT" 
   (	"PID" NUMBER(*,0), 
	"EID" NUMBER(*,0), 
	"PAY_MONTH" VARCHAR2(10), 
	"WOH_DAY" NUMBER(*,0), 
	"NIGHT" NUMBER(*,0), 
	"TOTAL_SALARY" NUMBER, 
	"LEAVE_DAYS" NUMBER(*,0), 
	"WORKING_HOUR" NUMBER, 
	"MEALALLOWANCE" NUMBER, 
	"WOSH_DAY" NUMBER
   ) ;
--------------------------------------------------------
--  DDL for Table POST_LIST
--------------------------------------------------------

  CREATE TABLE "POST_LIST" 
   (	"POST" VARCHAR2(20), 
	"BASIC_SALARY" NUMBER, 
	"POID" NUMBER
   ) ;
--------------------------------------------------------
--  DDL for Table ROLES
--------------------------------------------------------

  CREATE TABLE "ROLES" 
   (	"ROLEID" NUMBER(*,0), 
	"ROLENAME" VARCHAR2(10)
   ) ;
--------------------------------------------------------
--  DDL for Table USERROLES
--------------------------------------------------------

  CREATE TABLE "USERROLES" 
   (	"USERROLESID" NUMBER(*,0), 
	"ROLEID" NUMBER(*,0), 
	"EID" NUMBER(*,0)
   ) ;
--------------------------------------------------------
--  DDL for Table WORK_IN_OUT
--------------------------------------------------------

  CREATE TABLE "WORK_IN_OUT" 
   (	"IN_OUT_ID" NUMBER(*,0), 
	"EID" NUMBER(*,0), 
	"OUT_ON_WORK" TIMESTAMP (6), 
	"RETURN_INSIDE" TIMESTAMP (6), 
	"REASON" LONG
   ) ;

---------------------------------------------------
--   DATA FOR TABLE USERROLES
--   FILTER = none used
---------------------------------------------------
REM INSERTING into USERROLES
Insert into USERROLES (USERROLESID,ROLEID,EID) values (4,2,11);
Insert into USERROLES (USERROLESID,ROLEID,EID) values (5,2,12);
Insert into USERROLES (USERROLESID,ROLEID,EID) values (3,1,10);
Insert into USERROLES (USERROLESID,ROLEID,EID) values (2,1,9);

---------------------------------------------------
--   END DATA FOR TABLE USERROLES
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE LEAVES_TYPES
--   FILTER = none used
---------------------------------------------------
REM INSERTING into LEAVES_TYPES
Insert into LEAVES_TYPES (LTID,LEAVE_NAME,DAYS_OFF) values (1,'Casual Leave',5);
Insert into LEAVES_TYPES (LTID,LEAVE_NAME,DAYS_OFF) values (2,'Sick Leave',10);
Insert into LEAVES_TYPES (LTID,LEAVE_NAME,DAYS_OFF) values (3,'Home Leave',15);
Insert into LEAVES_TYPES (LTID,LEAVE_NAME,DAYS_OFF) values (4,'Maternity Leave',45);
Insert into LEAVES_TYPES (LTID,LEAVE_NAME,DAYS_OFF) values (6,'Bereavement Leave',15);
Insert into LEAVES_TYPES (LTID,LEAVE_NAME,DAYS_OFF) values (7,'Mourning Leave',2);

---------------------------------------------------
--   END DATA FOR TABLE LEAVES_TYPES
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE ALLOWANCE
--   FILTER = none used
---------------------------------------------------
REM INSERTING into ALLOWANCE
Insert into ALLOWANCE (POST,WOH,WONS,MEAL_ALLOWANCE,AID,WOSH) values ('HR',200,300,300,1,1000);

---------------------------------------------------
--   END DATA FOR TABLE ALLOWANCE
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE WORK_IN_OUT
--   FILTER = none used
---------------------------------------------------
REM INSERTING into WORK_IN_OUT

---------------------------------------------------
--   END DATA FOR TABLE WORK_IN_OUT
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE HOLIDAY_LIST
--   FILTER = none used
---------------------------------------------------
REM INSERTING into HOLIDAY_LIST
Insert into HOLIDAY_LIST (HID,H_DATE,OCCATION) values (1,to_timestamp('23-NOV-18 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),'dashain');
Insert into HOLIDAY_LIST (HID,H_DATE,OCCATION) values (3,to_timestamp('10-JAN-19 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),'HOliday');
Insert into HOLIDAY_LIST (HID,H_DATE,OCCATION) values (4,to_timestamp('26-DEC-18 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),'sdf');
Insert into HOLIDAY_LIST (HID,H_DATE,OCCATION) values (2,to_timestamp('13-DEC-18 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),'Tihar');

---------------------------------------------------
--   END DATA FOR TABLE HOLIDAY_LIST
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE POST_LIST
--   FILTER = none used
---------------------------------------------------
REM INSERTING into POST_LIST
Insert into POST_LIST (POST,BASIC_SALARY,POID) values ('HR',110,1);
Insert into POST_LIST (POST,BASIC_SALARY,POID) values ('Designer',85,2);
Insert into POST_LIST (POST,BASIC_SALARY,POID) values ('DBA',100,3);
Insert into POST_LIST (POST,BASIC_SALARY,POID) values ('Accountant',85,4);
Insert into POST_LIST (POST,BASIC_SALARY,POID) values ('IT Manager',140,5);
Insert into POST_LIST (POST,BASIC_SALARY,POID) values ('Programmer',55,6);
Insert into POST_LIST (POST,BASIC_SALARY,POID) values ('S Programmer',140,7);

---------------------------------------------------
--   END DATA FOR TABLE POST_LIST
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE EMPLOYEE_POST
--   FILTER = none used
---------------------------------------------------
REM INSERTING into EMPLOYEE_POST
Insert into EMPLOYEE_POST (EPOID,EID,POST) values (4,11,'DBA');
Insert into EMPLOYEE_POST (EPOID,EID,POST) values (5,12,'HR');
Insert into EMPLOYEE_POST (EPOID,EID,POST) values (3,10,'Designer');
Insert into EMPLOYEE_POST (EPOID,EID,POST) values (2,9,'HR');

---------------------------------------------------
--   END DATA FOR TABLE EMPLOYEE_POST
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE LEAVEDAYS
--   FILTER = none used
---------------------------------------------------
REM INSERTING into LEAVEDAYS
Insert into LEAVEDAYS (LDID,EID,LEAVETYPE,DAYS) values (1,9,'Casual Leave',0);
Insert into LEAVEDAYS (LDID,EID,LEAVETYPE,DAYS) values (2,9,'Home Leave',12);
Insert into LEAVEDAYS (LDID,EID,LEAVETYPE,DAYS) values (3,10,'Home Leave',13);

---------------------------------------------------
--   END DATA FOR TABLE LEAVEDAYS
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE LEAVE
--   FILTER = none used
---------------------------------------------------
REM INSERTING into LEAVE
Insert into LEAVE (LID,EID,LEAVE_TYPE,FROM_DATE,TO_DATE,DAYS,REASON,STATUS) values (3,9,'Sick leave',to_timestamp('13-DEC-18 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),to_timestamp('13-DEC-18 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),1,'1245787','UnKnown');
Insert into LEAVE (LID,EID,LEAVE_TYPE,FROM_DATE,TO_DATE,DAYS,REASON,STATUS) values (2,9,'Home leave',to_timestamp('22-NOV-18 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),to_timestamp('22-NOV-18 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),1,'123','Approved');
Insert into LEAVE (LID,EID,LEAVE_TYPE,FROM_DATE,TO_DATE,DAYS,REASON,STATUS) values (4,9,'casualleave',to_timestamp('20-DEC-18 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),to_timestamp('24-DEC-18 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),5,'1454','UnKnown');
Insert into LEAVE (LID,EID,LEAVE_TYPE,FROM_DATE,TO_DATE,DAYS,REASON,STATUS) values (1,9,'Home leave',to_timestamp('23-NOV-18 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),to_timestamp('27-NOV-18 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),5,'1234587','Declined');
Insert into LEAVE (LID,EID,LEAVE_TYPE,FROM_DATE,TO_DATE,DAYS,REASON,STATUS) values (5,9,'1',to_timestamp('13-DEC-18 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),to_timestamp('13-DEC-18 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),1,'mobile','UnKnown');

---------------------------------------------------
--   END DATA FOR TABLE LEAVE
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE MONTHLY_STATEMENT
--   FILTER = none used
---------------------------------------------------
REM INSERTING into MONTHLY_STATEMENT
Insert into MONTHLY_STATEMENT (MON_REC_ID,EID,MONTH,TOTALLEAVEDAYS,TOTALWORKINGHRS,TOTALNIGHTSHIFTS,TOTALWOH,TOTALWOSH,TOTALMEALALLOW) values (2,9,'01/0001',null,null,null,null,null,1);
Insert into MONTHLY_STATEMENT (MON_REC_ID,EID,MONTH,TOTALLEAVEDAYS,TOTALWORKINGHRS,TOTALNIGHTSHIFTS,TOTALWOH,TOTALWOSH,TOTALMEALALLOW) values (1,9,'12/2018',null,25.21391651691666367,10,2,3.20649957433333367,0);

---------------------------------------------------
--   END DATA FOR TABLE MONTHLY_STATEMENT
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE PAYOUT
--   FILTER = none used
---------------------------------------------------
REM INSERTING into PAYOUT
Insert into PAYOUT (PID,EID,PAY_MONTH,WOH_DAY,NIGHT,TOTAL_SALARY,LEAVE_DAYS,WORKING_HOUR,MEALALLOWANCE,WOSH_DAY) values (1,9,'12/2018',2,10,7575.2163429341663,0,25.08181742183333,0,3.07440047925);

---------------------------------------------------
--   END DATA FOR TABLE PAYOUT
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE EMPLOYEE
--   FILTER = none used
---------------------------------------------------
REM INSERTING into EMPLOYEE
Insert into EMPLOYEE (EID,FULL_NAME,ADDRESS,GENDER,EMAIL,PASSCODE,CONTACT) values (11,'alert','alert','M','alert@gmail.com','alert','9843354578');
Insert into EMPLOYEE (EID,FULL_NAME,ADDRESS,GENDER,EMAIL,PASSCODE,CONTACT) values (12,'Test','dfg','F','insert@gmail.com','12345','9845475414');
Insert into EMPLOYEE (EID,FULL_NAME,ADDRESS,GENDER,EMAIL,PASSCODE,CONTACT) values (10,'multiple','Test address','M','manish.9818544129@gmail.com','1212','9875744124');
Insert into EMPLOYEE (EID,FULL_NAME,ADDRESS,GENDER,EMAIL,PASSCODE,CONTACT) values (9,'rabin','kathmandu','M','12','12','9875477878');

---------------------------------------------------
--   END DATA FOR TABLE EMPLOYEE
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE ROLES
--   FILTER = none used
---------------------------------------------------
REM INSERTING into ROLES
Insert into ROLES (ROLEID,ROLENAME) values (1,'Admin');
Insert into ROLES (ROLEID,ROLENAME) values (2,'Staff');

---------------------------------------------------
--   END DATA FOR TABLE ROLES
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE ATTENDANCE
--   FILTER = none used
---------------------------------------------------
REM INSERTING into ATTENDANCE
Insert into ATTENDANCE (AID,EID,ATTEND_DATE,LOGIN_TIME,LOGOUT_TIME,SHIFT,TOTAL_TIME,LOGOUT_DATE) values (3,9,to_timestamp('13-DEC-18 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),to_timestamp('13-DEC-18 06.59.20.706453000 PM','DD-MON-RR HH.MI.SS.FF AM'),to_timestamp('13-DEC-18 06.59.34.882345000 PM','DD-MON-RR HH.MI.SS.FF AM'),'C',to_timestamp('13-DEC-18 12.00.14.175892000 AM','DD-MON-RR HH.MI.SS.FF AM'),to_timestamp('13-DEC-18 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'));
Insert into ATTENDANCE (AID,EID,ATTEND_DATE,LOGIN_TIME,LOGOUT_TIME,SHIFT,TOTAL_TIME,LOGOUT_DATE) values (1,9,to_timestamp('03-DEC-18 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),to_timestamp('03-DEC-18 07.00.00.000000000 PM','DD-MON-RR HH.MI.SS.FF AM'),to_timestamp('04-DEC-18 05.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),'C',to_timestamp('04-DEC-18 10.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),to_timestamp('04-DEC-18 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'));
Insert into ATTENDANCE (AID,EID,ATTEND_DATE,LOGIN_TIME,LOGOUT_TIME,SHIFT,TOTAL_TIME,LOGOUT_DATE) values (2,9,to_timestamp('04-DEC-18 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),to_timestamp('04-DEC-18 08.00.00.000000000 PM','DD-MON-RR HH.MI.SS.FF AM'),to_timestamp('04-DEC-18 11.00.00.000000000 PM','DD-MON-RR HH.MI.SS.FF AM'),'C',to_timestamp('04-DEC-18 03.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),to_timestamp('04-DEC-18 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'));

---------------------------------------------------
--   END DATA FOR TABLE ATTENDANCE
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE ATTENDANCE_CLAIM
--   FILTER = none used
---------------------------------------------------
REM INSERTING into ATTENDANCE_CLAIM
Insert into ATTENDANCE_CLAIM (CAID,EID,LOGIN_DATE,LOGIN_TIME,LOGOUT_DATE,LOGOUT_TIME,REASON,STATUS) values (4,9,to_timestamp('06-DEC-18 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),to_timestamp('06-DEC-18 06.00.00.000000000 PM','DD-MON-RR HH.MI.SS.FF AM'),null,null,null,'Pending');
Insert into ATTENDANCE_CLAIM (CAID,EID,LOGIN_DATE,LOGIN_TIME,LOGOUT_DATE,LOGOUT_TIME,REASON,STATUS) values (5,9,to_timestamp('06-DEC-18 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),to_timestamp('06-DEC-18 06.00.00.000000000 PM','DD-MON-RR HH.MI.SS.FF AM'),null,null,null,'Approved');
Insert into ATTENDANCE_CLAIM (CAID,EID,LOGIN_DATE,LOGIN_TIME,LOGOUT_DATE,LOGOUT_TIME,REASON,STATUS) values (6,9,to_timestamp('05-DEC-18 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),to_timestamp('05-DEC-18 07.00.00.000000000 PM','DD-MON-RR HH.MI.SS.FF AM'),null,null,null,'Approved');
Insert into ATTENDANCE_CLAIM (CAID,EID,LOGIN_DATE,LOGIN_TIME,LOGOUT_DATE,LOGOUT_TIME,REASON,STATUS) values (7,9,null,null,to_timestamp('06-DEC-18 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),to_timestamp('06-DEC-18 06.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),null,'Declined');
Insert into ATTENDANCE_CLAIM (CAID,EID,LOGIN_DATE,LOGIN_TIME,LOGOUT_DATE,LOGOUT_TIME,REASON,STATUS) values (8,9,to_timestamp('06-DEC-18 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),to_timestamp('06-DEC-18 07.00.00.000000000 PM','DD-MON-RR HH.MI.SS.FF AM'),null,null,'12','Declined');
Insert into ATTENDANCE_CLAIM (CAID,EID,LOGIN_DATE,LOGIN_TIME,LOGOUT_DATE,LOGOUT_TIME,REASON,STATUS) values (9,9,to_timestamp('03-DEC-18 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),to_timestamp('03-DEC-18 07.00.00.000000000 PM','DD-MON-RR HH.MI.SS.FF AM'),null,null,null,'Approved');
Insert into ATTENDANCE_CLAIM (CAID,EID,LOGIN_DATE,LOGIN_TIME,LOGOUT_DATE,LOGOUT_TIME,REASON,STATUS) values (10,9,null,null,to_timestamp('04-DEC-18 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),to_timestamp('04-DEC-18 05.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),null,'Approved');
Insert into ATTENDANCE_CLAIM (CAID,EID,LOGIN_DATE,LOGIN_TIME,LOGOUT_DATE,LOGOUT_TIME,REASON,STATUS) values (15,9,to_timestamp('03-DEC-18 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),to_timestamp('03-DEC-18 10.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),null,null,null,'Pending');
Insert into ATTENDANCE_CLAIM (CAID,EID,LOGIN_DATE,LOGIN_TIME,LOGOUT_DATE,LOGOUT_TIME,REASON,STATUS) values (1,10,to_timestamp('06-DEC-18 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),to_timestamp('06-DEC-18 10.00.00.000000000 PM','DD-MON-RR HH.MI.SS.FF AM'),null,null,null,'Approved');
Insert into ATTENDANCE_CLAIM (CAID,EID,LOGIN_DATE,LOGIN_TIME,LOGOUT_DATE,LOGOUT_TIME,REASON,STATUS) values (2,9,to_timestamp('06-DEC-18 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),to_timestamp('06-DEC-18 10.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),null,null,null,'Approved');
Insert into ATTENDANCE_CLAIM (CAID,EID,LOGIN_DATE,LOGIN_TIME,LOGOUT_DATE,LOGOUT_TIME,REASON,STATUS) values (3,9,null,null,to_timestamp('06-DEC-18 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),to_timestamp('06-DEC-18 03.00.00.000000000 PM','DD-MON-RR HH.MI.SS.FF AM'),null,'Pending');
Insert into ATTENDANCE_CLAIM (CAID,EID,LOGIN_DATE,LOGIN_TIME,LOGOUT_DATE,LOGOUT_TIME,REASON,STATUS) values (11,9,to_timestamp('03-DEC-18 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),to_timestamp('03-DEC-18 07.00.00.000000000 PM','DD-MON-RR HH.MI.SS.FF AM'),null,null,null,'Approved');
Insert into ATTENDANCE_CLAIM (CAID,EID,LOGIN_DATE,LOGIN_TIME,LOGOUT_DATE,LOGOUT_TIME,REASON,STATUS) values (12,9,to_timestamp('04-DEC-18 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),to_timestamp('04-DEC-18 08.00.00.000000000 PM','DD-MON-RR HH.MI.SS.FF AM'),null,null,null,'Approved');
Insert into ATTENDANCE_CLAIM (CAID,EID,LOGIN_DATE,LOGIN_TIME,LOGOUT_DATE,LOGOUT_TIME,REASON,STATUS) values (13,9,null,null,to_timestamp('04-DEC-18 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),to_timestamp('04-DEC-18 11.00.00.000000000 PM','DD-MON-RR HH.MI.SS.FF AM'),null,'Approved');
Insert into ATTENDANCE_CLAIM (CAID,EID,LOGIN_DATE,LOGIN_TIME,LOGOUT_DATE,LOGOUT_TIME,REASON,STATUS) values (14,9,null,null,to_timestamp('04-DEC-18 12.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),to_timestamp('04-DEC-18 05.00.00.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),null,'Approved');

---------------------------------------------------
--   END DATA FOR TABLE ATTENDANCE_CLAIM
---------------------------------------------------
--------------------------------------------------------
--  Constraints for Table ALLOWANCE
--------------------------------------------------------

  ALTER TABLE "ALLOWANCE" ADD PRIMARY KEY ("AID") ENABLE;
--------------------------------------------------------
--  Constraints for Table ATTENDANCE
--------------------------------------------------------

  ALTER TABLE "ATTENDANCE" ADD PRIMARY KEY ("AID") ENABLE;
--------------------------------------------------------
--  Constraints for Table ATTENDANCE_CLAIM
--------------------------------------------------------

  ALTER TABLE "ATTENDANCE_CLAIM" ADD CONSTRAINT "CONSTRAINT7" PRIMARY KEY ("CAID") ENABLE;
--------------------------------------------------------
--  Constraints for Table EMPLOYEE
--------------------------------------------------------

  ALTER TABLE "EMPLOYEE" ADD CONSTRAINT "EMPLOYEE_UK1" UNIQUE ("EMAIL") ENABLE;
 
  ALTER TABLE "EMPLOYEE" MODIFY ("FULL_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "EMPLOYEE" MODIFY ("ADDRESS" NOT NULL ENABLE);
 
  ALTER TABLE "EMPLOYEE" ADD PRIMARY KEY ("EID") ENABLE;
--------------------------------------------------------
--  Constraints for Table EMPLOYEE_POST
--------------------------------------------------------

  ALTER TABLE "EMPLOYEE_POST" ADD PRIMARY KEY ("EPOID") ENABLE;
--------------------------------------------------------
--  Constraints for Table HOLIDAY_LIST
--------------------------------------------------------

  ALTER TABLE "HOLIDAY_LIST" ADD PRIMARY KEY ("HID") ENABLE;
--------------------------------------------------------
--  Constraints for Table LEAVE
--------------------------------------------------------

  ALTER TABLE "LEAVE" ADD PRIMARY KEY ("LID") ENABLE;
--------------------------------------------------------
--  Constraints for Table LEAVEDAYS
--------------------------------------------------------

  ALTER TABLE "LEAVEDAYS" ADD CONSTRAINT "CONSTRAINT10" PRIMARY KEY ("LDID") ENABLE;
--------------------------------------------------------
--  Constraints for Table LEAVES_TYPES
--------------------------------------------------------

  ALTER TABLE "LEAVES_TYPES" ADD CONSTRAINT "CONSTRAINT9" PRIMARY KEY ("LTID") ENABLE;
--------------------------------------------------------
--  Constraints for Table MONTHLY_STATEMENT
--------------------------------------------------------

  ALTER TABLE "MONTHLY_STATEMENT" ADD CONSTRAINT "CONSTRAINT6" PRIMARY KEY ("MON_REC_ID") ENABLE;
--------------------------------------------------------
--  Constraints for Table PAYOUT
--------------------------------------------------------

  ALTER TABLE "PAYOUT" ADD PRIMARY KEY ("PID") ENABLE;
--------------------------------------------------------
--  Constraints for Table POST_LIST
--------------------------------------------------------

  ALTER TABLE "POST_LIST" ADD CONSTRAINT "CONSTRAINT1" PRIMARY KEY ("POID") ENABLE;
 
  ALTER TABLE "POST_LIST" ADD CONSTRAINT "CONSTRAINT2" UNIQUE ("POST") ENABLE;
--------------------------------------------------------
--  Constraints for Table ROLES
--------------------------------------------------------

  ALTER TABLE "ROLES" ADD PRIMARY KEY ("ROLEID") ENABLE;
--------------------------------------------------------
--  Constraints for Table USERROLES
--------------------------------------------------------

  ALTER TABLE "USERROLES" ADD PRIMARY KEY ("USERROLESID") ENABLE;
--------------------------------------------------------
--  Constraints for Table WORK_IN_OUT
--------------------------------------------------------

  ALTER TABLE "WORK_IN_OUT" ADD PRIMARY KEY ("IN_OUT_ID") ENABLE;
--------------------------------------------------------
--  DDL for Index CONSTRAINT1
--------------------------------------------------------

  CREATE UNIQUE INDEX "CONSTRAINT1" ON "POST_LIST" ("POID") 
  ;
--------------------------------------------------------
--  DDL for Index CONSTRAINT10
--------------------------------------------------------

  CREATE UNIQUE INDEX "CONSTRAINT10" ON "LEAVEDAYS" ("LDID") 
  ;
--------------------------------------------------------
--  DDL for Index CONSTRAINT2
--------------------------------------------------------

  CREATE UNIQUE INDEX "CONSTRAINT2" ON "POST_LIST" ("POST") 
  ;
--------------------------------------------------------
--  DDL for Index CONSTRAINT6
--------------------------------------------------------

  CREATE UNIQUE INDEX "CONSTRAINT6" ON "MONTHLY_STATEMENT" ("MON_REC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index CONSTRAINT7
--------------------------------------------------------

  CREATE UNIQUE INDEX "CONSTRAINT7" ON "ATTENDANCE_CLAIM" ("CAID") 
  ;
--------------------------------------------------------
--  DDL for Index CONSTRAINT9
--------------------------------------------------------

  CREATE UNIQUE INDEX "CONSTRAINT9" ON "LEAVES_TYPES" ("LTID") 
  ;
--------------------------------------------------------
--  DDL for Index EMPLOYEE_UK1
--------------------------------------------------------

  CREATE UNIQUE INDEX "EMPLOYEE_UK1" ON "EMPLOYEE" ("EMAIL") 
  ;
--------------------------------------------------------
--  Ref Constraints for Table ALLOWANCE
--------------------------------------------------------

  ALTER TABLE "ALLOWANCE" ADD CONSTRAINT "CONSTRAINT4" FOREIGN KEY ("POST")
	  REFERENCES "POST_LIST" ("POST") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table ATTENDANCE
--------------------------------------------------------

  ALTER TABLE "ATTENDANCE" ADD FOREIGN KEY ("EID")
	  REFERENCES "EMPLOYEE" ("EID") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table ATTENDANCE_CLAIM
--------------------------------------------------------

  ALTER TABLE "ATTENDANCE_CLAIM" ADD CONSTRAINT "CONSTRAINT8" FOREIGN KEY ("EID")
	  REFERENCES "EMPLOYEE" ("EID") ENABLE;

--------------------------------------------------------
--  Ref Constraints for Table EMPLOYEE_POST
--------------------------------------------------------

  ALTER TABLE "EMPLOYEE_POST" ADD CONSTRAINT "CONSTRAINT5" FOREIGN KEY ("POST")
	  REFERENCES "POST_LIST" ("POST") ENABLE;
 
  ALTER TABLE "EMPLOYEE_POST" ADD FOREIGN KEY ("EID")
	  REFERENCES "EMPLOYEE" ("EID") ENABLE;

--------------------------------------------------------
--  Ref Constraints for Table LEAVE
--------------------------------------------------------

  ALTER TABLE "LEAVE" ADD FOREIGN KEY ("EID")
	  REFERENCES "EMPLOYEE" ("EID") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table LEAVEDAYS
--------------------------------------------------------

  ALTER TABLE "LEAVEDAYS" ADD CONSTRAINT "CONSTRAINT11" FOREIGN KEY ("EID")
	  REFERENCES "EMPLOYEE" ("EID") ENABLE;

--------------------------------------------------------
--  Ref Constraints for Table MONTHLY_STATEMENT
--------------------------------------------------------

  ALTER TABLE "MONTHLY_STATEMENT" ADD CONSTRAINT "CONSTRAINT3" FOREIGN KEY ("EID")
	  REFERENCES "EMPLOYEE" ("EID") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table PAYOUT
--------------------------------------------------------

  ALTER TABLE "PAYOUT" ADD FOREIGN KEY ("EID")
	  REFERENCES "EMPLOYEE" ("EID") ENABLE;


--------------------------------------------------------
--  Ref Constraints for Table USERROLES
--------------------------------------------------------

  ALTER TABLE "USERROLES" ADD FOREIGN KEY ("ROLEID")
	  REFERENCES "ROLES" ("ROLEID") ENABLE;
 
  ALTER TABLE "USERROLES" ADD FOREIGN KEY ("EID")
	  REFERENCES "EMPLOYEE" ("EID") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table WORK_IN_OUT
--------------------------------------------------------

  ALTER TABLE "WORK_IN_OUT" ADD FOREIGN KEY ("EID")
	  REFERENCES "EMPLOYEE" ("EID") ENABLE;
