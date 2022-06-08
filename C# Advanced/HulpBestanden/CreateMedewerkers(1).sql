
-- Vermits er vreemde sleutels zijn --> eerst constraint verwijderen en dan drop table. (Drop table cascade constraints bestaat niet in sql server)
--alter table afdelingen  drop constraint A_HOOFD_FK
--GO
--alter table medewerkers drop constraint M_AFD_FK
--GO
--alter table uitvoeringen drop constraint U_DOCENT_FK
--GO
--alter table uitvoeringen drop constraint U_CURSUS_FK
--GO
--alter table inschrijvingen drop constraint I_UITV_FK   
--GO
--alter table inschrijvingen drop constraint I_CURSIST_FK
--GO


DROP TABLE if exists Medewerkers

create table  medewerkers
(mnr          smallint     constraint M_PK        primary key
                           constraint M_MNR_CHK   check (mnr > 7000)
,naam         NVARCHAR(15)  constraint M_NAAM_NN   not null
,voorn        NVARCHAR(12)   constraint M_VOORN_NN  not null
,functie      NVARCHAR(10)
,chef         smallint     constraint M_CHEF_FK   references medewerkers
,gbdatum      date     		constraint M_GEBDAT_NN not null
,maandsal     float        constraint M_MNDSAL_NN not null
,comm         float
,afd          smallint   default 10
,constraint M_AFD_CHK check ((case functie when 'VERKOPER' then 0 else 1 end) +
(case comm when null then 0 else 1 end) = 1)
)

GO

DROP TABLE if exists afdelingen

create table afdelingen
(anr     smallint    constraint A_PK       primary key
                      constraint A_ANR_CHK  check ( anr%10 = 0 )
,naam    NVARCHAR(20) constraint A_NAAM_NN  not null
                      constraint A_NAAM_UN  unique
                      constraint A_NAAM_CHK check (naam    = upper(naam)   )
,locatie NVARCHAR(20) constraint A_LOC_NN   not null
                      constraint A_LOC_CHK  check (locatie = upper(locatie))
,hoofd   smallint   constraint A_HOOFD_FK references medewerkers
)
GO

alter table medewerkers
add constraint M_AFD_FK foreign key (afd) references afdelingen
GO


DROP TABLE if exists schalen
GO

create table schalen
(snr          smallint  constraint S_PK         primary key
,ondergrens   float     constraint S_ONDER_NN   not null
                        constraint S_ONDER_CHK  check (ondergrens >= 0)
,bovengrens   float  constraint S_BOVEN_NN   not null
,toelage      float  constraint S_TOELG_NN   not null
,constraint   S_OND_BOV    check ( ondergrens  <=  bovengrens )
)
GO

DROP TABLE if exists cursussen
GO
create table  cursussen
(code         NVARCHAR(4)  constraint C_PK        primary key
,omschrijving NVARCHAR(50) constraint C_OMSCHR_NN not null
,type         CHAR(3)      constraint C_TYPE_NN   not null
,lengte       smallint    constraint C_LENGTE_NN not null
,constraint   C_CODE_CHK   check (code  =  upper(code)       )
,constraint   C_TYPE_CHK   check (type in ('ALG','BLD','DSG'))
)
GO

DROP TABLE if exists uitvoeringen
GO

create table  uitvoeringen
(cursus       NVARCHAR(4)  constraint U_CURSUS_NN not null
                           constraint U_CURSUS_FK references cursussen
,begindatum   DATE         constraint U_BEGIN_NN  not null
,docent       smallint  constraint U_DOCENT_FK references medewerkers
,locatie      NVARCHAR(20)
,constraint   U_PK         primary key (cursus,begindatum)
)
GO

DROP TABLE if exists inschrijvingen
GO

create table  inschrijvingen
(cursist      smallint    constraint  I_CURSIST_NN not null
                           constraint  I_CURSIST_FK references medewerkers
,cursus       NVARCHAR(4)  constraint  I_CURSUS_NN  not null
,begindatum   DATE         constraint  I_BEGIN_NN   not null
,evaluatie    smallint   constraint  I_EVAL_CHK
                           check       (evaluatie in (1,2,3,4,5) )
,constraint   I_PK         primary key (cursist,cursus,begindatum)
,constraint   I_UITV_FK    foreign key (cursus,begindatum)
                           references  uitvoeringen
)
GO