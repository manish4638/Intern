--------------------------------------------------------
--  File created - Monday-November-19-2018   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Sequence EID_INCREMENT
--------------------------------------------------------

   CREATE SEQUENCE  "ATTENDNET"."EID_INCREMENT"  MINVALUE 1 MAXVALUE 10000 INCREMENT BY 1 START WITH 21 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Table ALLOWANCE
--------------------------------------------------------

  CREATE TABLE "ATTENDNET"."ALLOWANCE" 
   (	"POST" VARCHAR2(20), 
	"WOH" NUMBER, 
	"WONS" NUMBER, 
	"MEAL_ALLOWANCE" NUMBER, 
	"AID" NUMBER(*,0)
   ) ;
--------------------------------------------------------
--  DDL for Table ATTENDANCE
--------------------------------------------------------

  CREATE TABLE "ATTENDNET"."ATTENDANCE" 
   (	"AID" NUMBER(*,0), 
	"EID" NUMBER(*,0), 
	"ATTEND_DATE" DATE, 
	"LOGIN_TIME" TIMESTAMP (6), 
	"LOGOUT_TIME" TIMESTAMP (6), 
	"SHIFT" VARCHAR2(15), 
	"TOTAL_TIME" TIMESTAMP (6)
   ) ;
--------------------------------------------------------
--  DDL for Table EMPLOYEE
--------------------------------------------------------

  CREATE TABLE "ATTENDNET"."EMPLOYEE" 
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

  CREATE TABLE "ATTENDNET"."EMPLOYEE_POST" 
   (	"EPOID" NUMBER(*,0), 
	"EID" NUMBER(*,0), 
	"POST" VARCHAR2(20)
   ) ;
--------------------------------------------------------
--  DDL for Table HOLIDAY_LIST
--------------------------------------------------------

  CREATE TABLE "ATTENDNET"."HOLIDAY_LIST" 
   (	"HID" NUMBER(*,0), 
	"H_DATE" DATE, 
	"OCCATION" VARCHAR2(30)
   ) ;
--------------------------------------------------------
--  DDL for Table LEAVE
--------------------------------------------------------

  CREATE TABLE "ATTENDNET"."LEAVE" 
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
--  DDL for Table MONTHLY_STATEMENT
--------------------------------------------------------

  CREATE TABLE "ATTENDNET"."MONTHLY_STATEMENT" 
   (	"MON_REC_ID" NUMBER, 
	"EID" NUMBER, 
	"MONTH" VARCHAR2(20), 
	"TOTALLEAVEDAYS" NUMBER, 
	"TOTALWORKINGHRS" NUMBER, 
	"TOTALNIGHTSHIFTS" NUMBER, 
	"TOTALWOH" NUMBER
   ) ;
--------------------------------------------------------
--  DDL for Table PAYOUT
--------------------------------------------------------

  CREATE TABLE "ATTENDNET"."PAYOUT" 
   (	"PID" NUMBER(*,0), 
	"EID" NUMBER(*,0), 
	"PAY_MONTH" VARCHAR2(10), 
	"WOH_DAY" NUMBER(*,0), 
	"NIGHT" NUMBER(*,0), 
	"TOTAL_SALARY" NUMBER, 
	"LEAVE_DAYS" NUMBER(*,0), 
	"WORKING_HOUR" NUMBER
   ) ;
--------------------------------------------------------
--  DDL for Table POST_LIST
--------------------------------------------------------

  CREATE TABLE "ATTENDNET"."POST_LIST" 
   (	"POST" VARCHAR2(20), 
	"BASIC_SALARY" NUMBER, 
	"POID" NUMBER
   ) ;
--------------------------------------------------------
--  DDL for Table ROLES
--------------------------------------------------------

  CREATE TABLE "ATTENDNET"."ROLES" 
   (	"ROLEID" NUMBER(*,0), 
	"ROLENAME" VARCHAR2(10)
   ) ;
--------------------------------------------------------
--  DDL for Table USERROLES
--------------------------------------------------------

  CREATE TABLE "ATTENDNET"."USERROLES" 
   (	"USERROLESID" NUMBER(*,0), 
	"ROLEID" NUMBER(*,0), 
	"EID" NUMBER(*,0)
   ) ;
--------------------------------------------------------
--  DDL for Table WORK_IN_OUT
--------------------------------------------------------

  CREATE TABLE "ATTENDNET"."WORK_IN_OUT" 
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
REM INSERTING into ATTENDNET.USERROLES
Insert into ATTENDNET.USERROLES (USERROLESID,ROLEID,EID) values (2,1,9);

---------------------------------------------------
--   END DATA FOR TABLE USERROLES
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE ALLOWANCE
--   FILTER = none used
---------------------------------------------------
REM INSERTING into ATTENDNET.ALLOWANCE

---------------------------------------------------
--   END DATA FOR TABLE ALLOWANCE
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE WORK_IN_OUT
--   FILTER = none used
---------------------------------------------------
REM INSERTING into ATTENDNET.WORK_IN_OUT

---------------------------------------------------
--   END DATA FOR TABLE WORK_IN_OUT
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE HOLIDAY_LIST
--   FILTER = none used
---------------------------------------------------
REM INSERTING into ATTENDNET.HOLIDAY_LIST

---------------------------------------------------
--   END DATA FOR TABLE HOLIDAY_LIST
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE POST_LIST
--   FILTER = none used
---------------------------------------------------
REM INSERTING into ATTENDNET.POST_LIST
Insert into ATTENDNET.POST_LIST (POST,BASIC_SALARY,POID) values ('HR',110,1);
Insert into ATTENDNET.POST_LIST (POST,BASIC_SALARY,POID) values ('Designer',85,2);
Insert into ATTENDNET.POST_LIST (POST,BASIC_SALARY,POID) values ('DBA',100,3);
Insert into ATTENDNET.POST_LIST (POST,BASIC_SALARY,POID) values ('Accountant',85,4);
Insert into ATTENDNET.POST_LIST (POST,BASIC_SALARY,POID) values ('IT Manager',140,5);
Insert into ATTENDNET.POST_LIST (POST,BASIC_SALARY,POID) values ('Programmer',55,6);
Insert into ATTENDNET.POST_LIST (POST,BASIC_SALARY,POID) values ('S Programmer',140,7);

---------------------------------------------------
--   END DATA FOR TABLE POST_LIST
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE EMPLOYEE_POST
--   FILTER = none used
---------------------------------------------------
REM INSERTING into ATTENDNET.EMPLOYEE_POST
Insert into ATTENDNET.EMPLOYEE_POST (EPOID,EID,POST) values (2,9,'HR');

---------------------------------------------------
--   END DATA FOR TABLE EMPLOYEE_POST
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE LEAVE
--   FILTER = none used
---------------------------------------------------
REM INSERTING into ATTENDNET.LEAVE

---------------------------------------------------
--   END DATA FOR TABLE LEAVE
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE MONTHLY_STATEMENT
--   FILTER = none used
---------------------------------------------------
REM INSERTING into ATTENDNET.MONTHLY_STATEMENT

---------------------------------------------------
--   END DATA FOR TABLE MONTHLY_STATEMENT
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE PAYOUT
--   FILTER = none used
---------------------------------------------------
REM INSERTING into ATTENDNET.PAYOUT

---------------------------------------------------
--   END DATA FOR TABLE PAYOUT
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE EMPLOYEE
--   FILTER = none used
---------------------------------------------------
REM INSERTING into ATTENDNET.EMPLOYEE
Insert into ATTENDNET.EMPLOYEE (EID,FULL_NAME,ADDRESS,GENDER,EMAIL,PASSCODE,CONTACT) values (9,'rabin','kathmandu','M','12','12','9875477878');

---------------------------------------------------
--   END DATA FOR TABLE EMPLOYEE
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE ROLES
--   FILTER = none used
---------------------------------------------------
REM INSERTING into ATTENDNET.ROLES
Insert into ATTENDNET.ROLES (ROLEID,ROLENAME) values (1,'Admin');
Insert into ATTENDNET.ROLES (ROLEID,ROLENAME) values (2,'Staff');

---------------------------------------------------
--   END DATA FOR TABLE ROLES
---------------------------------------------------

---------------------------------------------------
--   DATA FOR TABLE ATTENDANCE
--   FILTER = none used
---------------------------------------------------
REM INSERTING into ATTENDNET.ATTENDANCE

---------------------------------------------------
--   END DATA FOR TABLE ATTENDANCE
---------------------------------------------------
--------------------------------------------------------
--  Constraints for Table ALLOWANCE
--------------------------------------------------------

  ALTER TABLE "ATTENDNET"."ALLOWANCE" ADD PRIMARY KEY ("AID") ENABLE;
--------------------------------------------------------
--  Constraints for Table ATTENDANCE
--------------------------------------------------------

  ALTER TABLE "ATTENDNET"."ATTENDANCE" ADD PRIMARY KEY ("AID") ENABLE;
--------------------------------------------------------
--  Constraints for Table EMPLOYEE
--------------------------------------------------------

  ALTER TABLE "ATTENDNET"."EMPLOYEE" ADD CONSTRAINT "EMPLOYEE_UK1" UNIQUE ("EMAIL") ENABLE;
 
  ALTER TABLE "ATTENDNET"."EMPLOYEE" MODIFY ("FULL_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "ATTENDNET"."EMPLOYEE" MODIFY ("ADDRESS" NOT NULL ENABLE);
 
  ALTER TABLE "ATTENDNET"."EMPLOYEE" ADD PRIMARY KEY ("EID") ENABLE;
--------------------------------------------------------
--  Constraints for Table EMPLOYEE_POST
--------------------------------------------------------

  ALTER TABLE "ATTENDNET"."EMPLOYEE_POST" ADD PRIMARY KEY ("EPOID") ENABLE;
--------------------------------------------------------
--  Constraints for Table HOLIDAY_LIST
--------------------------------------------------------

  ALTER TABLE "ATTENDNET"."HOLIDAY_LIST" ADD PRIMARY KEY ("HID") ENABLE;
--------------------------------------------------------
--  Constraints for Table LEAVE
--------------------------------------------------------

  ALTER TABLE "ATTENDNET"."LEAVE" ADD PRIMARY KEY ("LID") ENABLE;
--------------------------------------------------------
--  Constraints for Table MONTHLY_STATEMENT
--------------------------------------------------------

  ALTER TABLE "ATTENDNET"."MONTHLY_STATEMENT" ADD CONSTRAINT "CONSTRAINT6" PRIMARY KEY ("MON_REC_ID") ENABLE;
--------------------------------------------------------
--  Constraints for Table PAYOUT
--------------------------------------------------------

  ALTER TABLE "ATTENDNET"."PAYOUT" ADD PRIMARY KEY ("PID") ENABLE;
--------------------------------------------------------
--  Constraints for Table POST_LIST
--------------------------------------------------------

  ALTER TABLE "ATTENDNET"."POST_LIST" ADD CONSTRAINT "CONSTRAINT1" PRIMARY KEY ("POID") ENABLE;
 
  ALTER TABLE "ATTENDNET"."POST_LIST" ADD CONSTRAINT "CONSTRAINT2" UNIQUE ("POST") ENABLE;
--------------------------------------------------------
--  Constraints for Table ROLES
--------------------------------------------------------

  ALTER TABLE "ATTENDNET"."ROLES" ADD PRIMARY KEY ("ROLEID") ENABLE;
--------------------------------------------------------
--  Constraints for Table USERROLES
--------------------------------------------------------

  ALTER TABLE "ATTENDNET"."USERROLES" ADD PRIMARY KEY ("USERROLESID") ENABLE;
--------------------------------------------------------
--  Constraints for Table WORK_IN_OUT
--------------------------------------------------------

  ALTER TABLE "ATTENDNET"."WORK_IN_OUT" ADD PRIMARY KEY ("IN_OUT_ID") ENABLE;
--------------------------------------------------------
--  DDL for Index CONSTRAINT1
--------------------------------------------------------

  CREATE UNIQUE INDEX "ATTENDNET"."CONSTRAINT1" ON "ATTENDNET"."POST_LIST" ("POID") 
  ;
--------------------------------------------------------
--  DDL for Index CONSTRAINT2
--------------------------------------------------------

  CREATE UNIQUE INDEX "ATTENDNET"."CONSTRAINT2" ON "ATTENDNET"."POST_LIST" ("POST") 
  ;
--------------------------------------------------------
--  DDL for Index CONSTRAINT6
--------------------------------------------------------

  CREATE UNIQUE INDEX "ATTENDNET"."CONSTRAINT6" ON "ATTENDNET"."MONTHLY_STATEMENT" ("MON_REC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index EMPLOYEE_UK1
--------------------------------------------------------

  CREATE UNIQUE INDEX "ATTENDNET"."EMPLOYEE_UK1" ON "ATTENDNET"."EMPLOYEE" ("EMAIL") 
  ;
--------------------------------------------------------
--  Ref Constraints for Table ALLOWANCE
--------------------------------------------------------

  ALTER TABLE "ATTENDNET"."ALLOWANCE" ADD CONSTRAINT "CONSTRAINT4" FOREIGN KEY ("POST")
	  REFERENCES "ATTENDNET"."POST_LIST" ("POST") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table ATTENDANCE
--------------------------------------------------------

  ALTER TABLE "ATTENDNET"."ATTENDANCE" ADD FOREIGN KEY ("EID")
	  REFERENCES "ATTENDNET"."EMPLOYEE" ("EID") ENABLE;

--------------------------------------------------------
--  Ref Constraints for Table EMPLOYEE_POST
--------------------------------------------------------

  ALTER TABLE "ATTENDNET"."EMPLOYEE_POST" ADD CONSTRAINT "CONSTRAINT5" FOREIGN KEY ("POST")
	  REFERENCES "ATTENDNET"."POST_LIST" ("POST") ENABLE;
 
  ALTER TABLE "ATTENDNET"."EMPLOYEE_POST" ADD FOREIGN KEY ("EID")
	  REFERENCES "ATTENDNET"."EMPLOYEE" ("EID") ENABLE;

--------------------------------------------------------
--  Ref Constraints for Table LEAVE
--------------------------------------------------------

  ALTER TABLE "ATTENDNET"."LEAVE" ADD FOREIGN KEY ("EID")
	  REFERENCES "ATTENDNET"."EMPLOYEE" ("EID") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table MONTHLY_STATEMENT
--------------------------------------------------------

  ALTER TABLE "ATTENDNET"."MONTHLY_STATEMENT" ADD CONSTRAINT "CONSTRAINT3" FOREIGN KEY ("EID")
	  REFERENCES "ATTENDNET"."EMPLOYEE" ("EID") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table PAYOUT
--------------------------------------------------------

  ALTER TABLE "ATTENDNET"."PAYOUT" ADD FOREIGN KEY ("EID")
	  REFERENCES "ATTENDNET"."EMPLOYEE" ("EID") ENABLE;


--------------------------------------------------------
--  Ref Constraints for Table USERROLES
--------------------------------------------------------

  ALTER TABLE "ATTENDNET"."USERROLES" ADD FOREIGN KEY ("ROLEID")
	  REFERENCES "ATTENDNET"."ROLES" ("ROLEID") ENABLE;
 
  ALTER TABLE "ATTENDNET"."USERROLES" ADD FOREIGN KEY ("EID")
	  REFERENCES "ATTENDNET"."EMPLOYEE" ("EID") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table WORK_IN_OUT
--------------------------------------------------------

  ALTER TABLE "ATTENDNET"."WORK_IN_OUT" ADD FOREIGN KEY ("EID")
	  REFERENCES "ATTENDNET"."EMPLOYEE" ("EID") ENABLE;
