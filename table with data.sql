--------------------------------------------------------
--  File created - Wednesday-December-19-2018   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Sequence EID_INCREMENT
--------------------------------------------------------

   
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
	"STATUS" VARCHAR2(20), 
	"COMENT" VARCHAR2(60)
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
	"STATUS" VARCHAR2(20), 
	"REQUESTED_FROM" DATE, 
	"REQUESTED_TO" DATE, 
	"COMENT" VARCHAR2(150)
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
--  DDL for Table REPORTTOSUPERVISOR
--------------------------------------------------------

  CREATE TABLE "REPORTTOSUPERVISOR" 
   (	"RTSID" NUMBER, 
	"SUPERVISOR" VARCHAR2(60), 
	"MESSAGE" VARCHAR2(200), 
	"EMAIL" VARCHAR2(60)
   ) ;
--------------------------------------------------------
--  DDL for Table ROLES
--------------------------------------------------------

  CREATE TABLE "ROLES" 
   (	"ROLEID" NUMBER(*,0), 
	"ROLENAME" VARCHAR2(30)
   ) ;
--------------------------------------------------------
--  DDL for Table SUPERVISOR
--------------------------------------------------------

  CREATE TABLE "SUPERVISOR" 
   (	"EID" NUMBER, 
	"SUPERVISOR1" VARCHAR2(60), 
	"SUPERVISOR2" VARCHAR2(60), 
	"SUPERVISOR3" VARCHAR2(60), 
	"SUPERVISOR4" VARCHAR2(60), 
	"SUPERVISOR5" VARCHAR2(60)
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
--   DATA FOR TABLE SUPERVISOR
--   FILTER = none used
---------------------------------------------------
REM INSERTING into SUPERVISOR
Insert into SUPERVISOR (EID,SUPERVISOR1,SUPERVISOR2,SUPERVISOR3,SUPERVISOR4,SUPERVISOR5) values (1,'nepasoft','p@mail.com','hfg@mail.vo','Null','Null');

---------------------------------------------------
--   END DATA FOR TABLE SUPERVISOR
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE USERROLES
--   FILTER = none used
---------------------------------------------------
REM INSERTING into USERROLES
Insert into USERROLES (USERROLESID,ROLEID,EID) values (1,1,1);

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
Insert into LEAVES_TYPES (LTID,LEAVE_NAME,DAYS_OFF) values (5,'Bereavement Leave',15);
Insert into LEAVES_TYPES (LTID,LEAVE_NAME,DAYS_OFF) values (6,'Mourning Leave',2);

---------------------------------------------------
--   END DATA FOR TABLE LEAVES_TYPES
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE ALLOWANCE
--   FILTER = none used
---------------------------------------------------
REM INSERTING into ALLOWANCE
Insert into ALLOWANCE (POST,WOH,WONS,MEAL_ALLOWANCE,AID,WOSH) values ('HR',null,300,300,1,1000);

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

---------------------------------------------------
--   END DATA FOR TABLE HOLIDAY_LIST
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE POST_LIST
--   FILTER = none used
---------------------------------------------------
REM INSERTING into POST_LIST
Insert into POST_LIST (POST,BASIC_SALARY,POID) values ('HR',110,1);

---------------------------------------------------
--   END DATA FOR TABLE POST_LIST
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE EMPLOYEE_POST
--   FILTER = none used
---------------------------------------------------
REM INSERTING into EMPLOYEE_POST
Insert into EMPLOYEE_POST (EPOID,EID,POST) values (1,1,'HR');

---------------------------------------------------
--   END DATA FOR TABLE EMPLOYEE_POST
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE LEAVEDAYS
--   FILTER = none used
---------------------------------------------------
REM INSERTING into LEAVEDAYS
Insert into LEAVEDAYS (LDID,EID,LEAVETYPE,DAYS) values (2,1,'Casual Leave',0);
Insert into LEAVEDAYS (LDID,EID,LEAVETYPE,DAYS) values (3,1,'Sick Leave',0);
Insert into LEAVEDAYS (LDID,EID,LEAVETYPE,DAYS) values (1,1,'Home Leave',0);
Insert into LEAVEDAYS (LDID,EID,LEAVETYPE,DAYS) values (4,1,'Maternity Leave',0);
Insert into LEAVEDAYS (LDID,EID,LEAVETYPE,DAYS) values (5,1,'Bereavement Leave',0);
Insert into LEAVEDAYS (LDID,EID,LEAVETYPE,DAYS) values (6,1,null,null);

---------------------------------------------------
--   END DATA FOR TABLE LEAVEDAYS
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE LEAVE
--   FILTER = none used
---------------------------------------------------
REM INSERTING into LEAVE

---------------------------------------------------
--   END DATA FOR TABLE LEAVE
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE MONTHLY_STATEMENT
--   FILTER = none used
---------------------------------------------------
REM INSERTING into MONTHLY_STATEMENT

---------------------------------------------------
--   END DATA FOR TABLE MONTHLY_STATEMENT
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE PAYOUT
--   FILTER = none used
---------------------------------------------------
REM INSERTING into PAYOUT

---------------------------------------------------
--   END DATA FOR TABLE PAYOUT
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE ROLES
--   FILTER = none used
---------------------------------------------------
REM INSERTING into ROLES
Insert into ROLES (ROLEID,ROLENAME) values (3,'Project Manager');
Insert into ROLES (ROLEID,ROLENAME) values (1,'Admin');
Insert into ROLES (ROLEID,ROLENAME) values (2,'Staff');

---------------------------------------------------
--   END DATA FOR TABLE ROLES
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE EMPLOYEE
--   FILTER = none used
---------------------------------------------------
REM INSERTING into EMPLOYEE
Insert into EMPLOYEE (EID,FULL_NAME,ADDRESS,GENDER,EMAIL,PASSCODE,CONTACT) values (1,'rabindranath','kathmand','M','manish.shrestha3539@gmail.com','N@bins46','9875477878');

---------------------------------------------------
--   END DATA FOR TABLE EMPLOYEE
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE REPORTTOSUPERVISOR
--   FILTER = none used
---------------------------------------------------
REM INSERTING into REPORTTOSUPERVISOR

---------------------------------------------------
--   END DATA FOR TABLE REPORTTOSUPERVISOR
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE ATTENDANCE
--   FILTER = none used
---------------------------------------------------
REM INSERTING into ATTENDANCE

---------------------------------------------------
--   END DATA FOR TABLE ATTENDANCE
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE ATTENDANCE_CLAIM
--   FILTER = none used
---------------------------------------------------
REM INSERTING into ATTENDANCE_CLAIM

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
--  Constraints for Table REPORTTOSUPERVISOR
--------------------------------------------------------

  ALTER TABLE "REPORTTOSUPERVISOR" ADD CONSTRAINT "CONSTRAINT13" PRIMARY KEY ("RTSID") ENABLE;
--------------------------------------------------------
--  Constraints for Table ROLES
--------------------------------------------------------

  ALTER TABLE "ROLES" ADD PRIMARY KEY ("ROLEID") ENABLE;
--------------------------------------------------------
--  Constraints for Table SUPERVISOR
--------------------------------------------------------

  ALTER TABLE "SUPERVISOR" ADD CONSTRAINT "CONSTRAINT12" PRIMARY KEY ("EID") ENABLE;
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
--  DDL for Index CONSTRAINT12
--------------------------------------------------------

  CREATE UNIQUE INDEX "CONSTRAINT12" ON "SUPERVISOR" ("EID") 
  ;
--------------------------------------------------------
--  DDL for Index CONSTRAINT13
--------------------------------------------------------

  CREATE UNIQUE INDEX "CONSTRAINT13" ON "REPORTTOSUPERVISOR" ("RTSID") 
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
--  Ref Constraints for Table REPORTTOSUPERVISOR
--------------------------------------------------------

  ALTER TABLE "REPORTTOSUPERVISOR" ADD CONSTRAINT "CONSTRAINT14" FOREIGN KEY ("EMAIL")
	  REFERENCES "EMPLOYEE" ("EMAIL") ENABLE;


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
