use Medewerkers
GO

--
-- Vreemde sleutels uitschakelen.
--
--alter table historie nocheck constraint h_afd_fk
--GO
alter table afdelingen  nocheck constraint A_HOOFD_FK
GO
alter table medewerkers nocheck constraint M_AFD_FK
GO
alter table medewerkers nocheck constraint M_AFD_CHK
GO
alter table medewerkers nocheck constraint M_CHEF_FK
GO
alter table uitvoeringen nocheck constraint U_DOCENT_FK
GO
alter table uitvoeringen nocheck constraint U_CURSUS_FK
GO
alter table inschrijvingen nocheck constraint I_UITV_FK   
GO
alter table inschrijvingen nocheck constraint I_CURSIST_FK
GO

-- alter    index  med_PK on medewerkers disable
-- Door de PK sleutel uit te schakelen worden onderstaande vreemde sleutels ook uitgeschakeld. BOvendien kan je dan geen INSERT, DELETE,.... doen

-- Warning: Foreign key 'afd_hoofd_FK' on table 'AFDELINGEN' referencing table 'MEDEWERKERS' was disabled as a result of disabling the index 'med_pk'.
-- Warning: Foreign key 'h_mnr_FK' on table 'HISTORIE' referencing table 'MEDEWERKERS' was disabled as a result of disabling the index 'med_pk'.
-- Warning: Foreign key 'u_docent_fk' on table 'UITVOERINGEN' referencing table 'MEDEWERKERS' was disabled as a result of disabling the index 'med_pk'.
-- Warning: Foreign key 'i_cursist_FK' on table 'INSCHRIJVINGEN' referencing table 'MEDEWERKERS' was disabled as a result of disabling the index 'med_pk'.
-- Warning: Foreign key 'med_chef_fk' on table 'MEDEWERKERS' referencing table 'MEDEWERKERS' was disabled as a result of disabling the index 'med_pk'.
-- Warning: Foreign key 'med_afd_fk' on table 'MEDEWERKERS' referencing table 'AFDELINGEN' was disabled as a result of disabling the index 'med_pk'.
-- Warning: Foreign key 'med_chef_fk' on table 'MEDEWERKERS' referencing table 'MEDEWERKERS' was disabled as a result of disabling the index 'med_pk'.

-- PK terug aanzetten
--alter index med_pk on medewerkers rebuild

-- -----------------------------------------
-- Tabel MEDEWERKERS maken
-- -----------------------------------------

delete MEDEWERKERS
GO

insert into medewerkers values(7369,'CASPERS' ,'JANA'  ,'TRAINER'   ,7902,   '17-DEC-1985'  , 1800 , NULL       ,20),
(7499,'ALLARD'     ,'NELE','VERKOPER'  ,7698 ,'20-FEB-1981'  , 1600, 3000        ,30),
(7521,'DEFOUR'   ,'THOMAS' ,'VERKOPER'  ,7698 ,'22-FEB-1982'  , 2250, 5000        ,30),
(7566,'JACOBS'     ,'EMMA' ,'MANAGER'   ,7839  ,'02-APR-1987'  , 4975, NULL       ,20),
(7654,'MARTENS'    ,'RAF'  ,'VERKOPER'  ,7698   ,'28-SEP-1976'  , 2250, 3400       ,30),
(7698,'BRIERS'      ,'ANDREA'  ,'MANAGER'   ,7839  ,'01-NOV-1983'  , 5850, NULL       ,30),
(7782,'CLERCKX'    ,'AN' ,'MANAGER'   ,7839  ,'09-JUN-1985'  , 3450, NULL       ,10),
(7788,'SWINNEN'   ,'CHRIS','TRAINER'   ,7566  ,'26-NOV-1979'  , 4000, NULL       ,20),
(7839,'DE KONING'  ,'LIEVE' ,'DIRECTEUR' ,NULL    ,'17-NOV-1972'  , 7000, NULL       ,10),
(7844,'DEN RUYTER','JOACHIM' ,'VERKOPER'  ,7698   ,'28-SEP-1988'  , 2500, 0          ,30),
(7876,'SLECHTEN'      ,'TOM' ,'TRAINER'   ,7788   ,'30-DEC-1986'  , 2700, NULL       ,20),
(7900,'JACOBS'     ,'SIMON'  ,'BOEKHOUDER',7698      ,'03-DEC-1989'  , 2800 , NULL       ,30),
(7902,'DE COOMAN'    ,'DORIEN' ,'TRAINER'   ,7566, '13-FEB-1979'  , 4000, NULL       ,20),
(7934,'WOUTERS'   ,'SVEN','BOEKHOUDER',7782      ,'23-JAN-1982'  , 2300, NULL       ,10)
GO

-- -----------------------------------
-- Tabel AFDELINGEN maken
-- -----------------------------------
delete afdelingen
GO

insert into afdelingen values (10,'HOOFDKANTOOR'   ,'MAASMECHELEN'   ,7782),
 (20,'OPLEIDINGEN'    ,'HASSELT' ,7566),
 (30,'VERKOOP'        ,'GENK'  ,7698),
(40,'PERSONEELSZAKEN','LEUVEN',7839)
GO



-- -----------------------------------
-- Tabel SCHALEN maken
-- -----------------------------------
delete schalen;
GO

insert into schalen    values (1, 1700,2200,  0),
(2,2201,2400, 50),
 (3,2401,4000,100),
 (4,4001,5000,200),
 (5,5001,9999,500)
 GO

 -- -----------------------------------
-- Tabel CURSUSSEN maken
-- -----------------------------------
  delete cursussen
 GO

 insert into cursussen  values ('SQL','Introductie SQL en databanken'    ,'ALG',4),
('ORG','IT Organisatie'     ,'ALG',1), 
('WEB','Ontwikkeling website'     ,'BLD',4),
('CIS','Cisco CCNA'  ,'BLD',1),
 ('WIN','Windows Server'  ,'BLD',2),
 ('LIN','Linux OS'  ,'DSG',3),
 ('PR2','Programmeren2 in Visual C#'  ,'DSG',1),
 ('WBA','Web applicaties'       ,'DSG',2),
 ('PR1','Programmeren1 Visual C#' ,'DSG',5),
 ('NET','Netwerkbeheer' ,'DSG',4)
 GO


 -- -----------------------------------
-- Tabel UITVOERINGEN maken
-- -----------------------------------
 delete uitvoeringen
 GO

 insert into uitvoeringen   values ('SQL','2015-04-16',7902,'HASSELT'  ),
 ('SQL','2015-10-08',7369,'MAASEIK'),
('SQL','2015-12-17',7369,'HASSELT'  ),
 ('ORG','2015-08-10',7566,'GENK'   ),
 ('ORG','2015-09-27',7902,'HASSELT'  ),
 ('WEB','2015-12-17',7566,'MAASEIK'),
 ('WEB','2016-02-05',7876,'HASSELT'  ),
 ('CIS','2016-09-11',7788,'HASSELT'  ),
('WIN','2016-02-04',7369,'HASSELT'  ),
 ('WIN','2016-09-18',NULL,'MAASEIK'),
('LIN','2017-01-13',NULL, NULL       ),
 ('PR1','2017-02-17',NULL,'HASSELT'  ),
 ('WBA','2017-02-24',7788,'GENK'   )
 GO

 
 -- -----------------------------------
-- Tabel INSCHRIJVINGEN maken
-- -----------------------------------
 delete inschrijvingen
 GO

insert into inschrijvingen values (7499,'SQL','16-APR-2015',4   )
insert into inschrijvingen values (7934,'SQL','16-APR-2015',5   )
insert into inschrijvingen values (7698,'SQL','16-APR-2015',4   )
insert into inschrijvingen values (7876,'SQL','16-APR-2015',2   )
insert into inschrijvingen values (7788,'SQL','08-OCT-2015',NULL)
insert into inschrijvingen values (7839,'SQL','08-OCT-2015',3   )
insert into inschrijvingen values (7902,'SQL','08-OCT-2015',4   )
insert into inschrijvingen values (7902,'SQL','17-DEC-2015',NULL)
insert into inschrijvingen values (7698,'SQL','17-DEC-2015',NULL)
insert into inschrijvingen values (7521,'ORG','10-AUG-2015',4   )
insert into inschrijvingen values (7900,'ORG','10-AUG-2015',4   )
insert into inschrijvingen values (7902,'ORG','10-AUG-2015',5   )
insert into inschrijvingen values (7844,'ORG','27-SEP-2016',5   ) 
insert into inschrijvingen values (7499,'WEB','17-DEC-2015',2   )
insert into inschrijvingen values (7782,'WEB','17-DEC-2015',5   )
insert into inschrijvingen values (7876,'WEB','17-DEC-2015',5   )
insert into inschrijvingen values (7788,'WEB','17-DEC-2015',5   )
insert into inschrijvingen values (7839,'WEB','17-DEC-2015',4   )
insert into inschrijvingen values (7566,'WEB','05-FEB-2016',3   )
insert into inschrijvingen values (7788,'WEB','05-FEB-2016',4   )
insert into inschrijvingen values (7698,'WEB','05-FEB-2016',5   )
insert into inschrijvingen values (7900,'WIN','04-FEB-2016',4   )
insert into inschrijvingen values (7499,'WIN','04-FEB-2016',5   )
insert into inschrijvingen values (7566,'CIS','11-SEP-2016',NULL)
insert into inschrijvingen values (7499,'CIS','11-SEP-2016',NULL)
insert into inschrijvingen values (7876,'CIS','11-SEP-2016',NULL)
GO


---- -----------------------------------
---- Tabel HISTORIE maken
---- -----------------------------------
--delete historie
--GO

--insert into historie values(7369,2015,'2015-01-01',null,20,1800,null)
--insert into historie values(7499,2010,'2010-06-01','2014-11-01',30,1000,null)
--insert into historie values(7499,2014,'2014-11-01',null,30,1600,'Targets gehaald')
--insert into historie values(7521,1999,'1999-08-01',null,30,2250,'Blijft liefs op afdeling.')
--insert into historie values(7566,2011,'2011-12-01','2019-03-01',20,3500,'Ongeschikt als docent, wel leiderschapskwaliteiten')
--insert into historie values(7566,2019,'2019-03-01',null,20,4975,'Promotie')
--insert into historie values(7654,2019,'2019-01-01',null,30,2250,'Senior verkoper, op te volgen')
--insert into historie values(7698,2007,'2007-01-01','2012-01-01',30,3000,'Goede start als verkoper')
--insert into historie values(7698,2012,'2012-01-01','2019-04-01',30,4350,'Promotie!')
--insert into historie values(7698,2019,'2019-04-01',null,30,5850,'Hoofd van afdeling verkoop.')
--insert into historie values(7782,2015,'2015-10-15',null,10,3450,'Aangenomen als manager voor hoofdskantoor.')
--insert into historie values(7788,2004,'2004-07-10',null,20,4000,null)
--insert into historie values(7839,1996,'1996-01-01','2010-01-01',20,2500,'Oprichter bedrijf')
--insert into historie values(7839,2010,'2010-01-01',null,10,7000,'Afsplitsing naar hoofdkantoor')
--insert into historie values(7844,2008,'2008-08-07',null,30,2500,null)
--insert into historie values(7876,2004,'2004-05-20','2016-09-14',20,2000,'Junior medewerker, mentor toegewezen.')
--insert into historie values(7876,2016,'2016-09-14',null,20,2700,'Salaris verhoging wegens goed project.')
--insert into historie values(7900,2015,'2015-01-01',null,30,2800,null)
--insert into historie values(7902,1998,'1998-12-01',null,20,4000,null)
--insert into historie values(7934,2005,'2005-09-15','2017-11-15',30,1980,null)
--insert into historie values(7934,2017,'2017-11-15',null,10,2300,'Overplaatsing naar hoofdkantoor')
--GO

-- -----------------------------------
-- Vreemde sleutels terug inschakelen.
-- -----------------------------------


--alter table historie check constraint h_afd_fk
--GO
alter table afdelingen  check constraint A_HOOFD_FK
GO
alter table medewerkers check constraint M_AFD_CHK
GO
alter table medewerkers check constraint M_AFD_FK
GO
alter table medewerkers check constraint M_CHEF_FK
GO
alter table uitvoeringen check constraint U_DOCENT_FK
GO
alter table uitvoeringen check constraint U_CURSUS_FK
GO
alter table inschrijvingen check constraint I_UITV_FK   
GO
alter table inschrijvingen check constraint I_CURSIST_FK
GO