--------------------------------------------------------
-- Archivo creado  - viernes-julio-15-2022   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Sequence IDAUTOR_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "PRUEBA_NEXOS"."IDAUTOR_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 17 NOCACHE  NOORDER  NOCYCLE  NOKEEP  NOSCALE  GLOBAL
--------------------------------------------------------
--  DDL for Sequence IDLIBRO_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "PRUEBA_NEXOS"."IDLIBRO_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 20 NOCACHE  NOORDER  NOCYCLE  NOKEEP  NOSCALE  GLOBAL
--------------------------------------------------------
--  DDL for Table TBL_AUTOR
--------------------------------------------------------

  CREATE TABLE "PRUEBA_NEXOS"."TBL_AUTOR" ("IdAutor" NUMBER, "autNombreCompleto" VARCHAR2(50), "autFchNacimiento" DATE, "autCiudad" VARCHAR2(100), "autCorreo" VARCHAR2(50))
--------------------------------------------------------
--  DDL for Table TBL_LIBRO
--------------------------------------------------------

  CREATE TABLE "PRUEBA_NEXOS"."TBL_LIBRO" ("IdLibro" NUMBER, "lbrTitulo" VARCHAR2(100), "lbrAnio" VARCHAR2(100), "lbrGenero" VARCHAR2(100), "lbrNumPag" NUMBER, "IdAutor" NUMBER)
REM INSERTING into PRUEBA_NEXOS.TBL_AUTOR
SET DEFINE OFF;
Insert into PRUEBA_NEXOS.TBL_AUTOR ("IdAutor","autNombreCompleto","autFchNacimiento","autCiudad","autCorreo") values ('1','Anonimo',to_date('12/12/21','DD/MM/RR'),'Desconocido','anonimo@gmail.com');
Insert into PRUEBA_NEXOS.TBL_AUTOR ("IdAutor","autNombreCompleto","autFchNacimiento","autCiudad","autCorreo") values ('2','Gabriel Garcia',to_date('15/07/64','DD/MM/RR'),'Santa Marta','gabrielg@gmail.com');
Insert into PRUEBA_NEXOS.TBL_AUTOR ("IdAutor","autNombreCompleto","autFchNacimiento","autCiudad","autCorreo") values ('3','Presidente',to_date('12/11/91','DD/MM/RR'),'Bogota','presidente@gmail.com');
REM INSERTING into PRUEBA_NEXOS.TBL_LIBRO
SET DEFINE OFF;
Insert into PRUEBA_NEXOS.TBL_LIBRO ("IdLibro","lbrTitulo","lbrAnio","lbrGenero","lbrNumPag","IdAutor") values ('1','La divina comedia','1456','Drama','590','1');
--------------------------------------------------------
--  DDL for Index TBL_AUTOR_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "PRUEBA_NEXOS"."TBL_AUTOR_PK" ON "PRUEBA_NEXOS"."TBL_AUTOR" ("IdAutor")
--------------------------------------------------------
--  DDL for Index TBL_LIBRO_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "PRUEBA_NEXOS"."TBL_LIBRO_PK" ON "PRUEBA_NEXOS"."TBL_LIBRO" ("IdLibro")
--------------------------------------------------------
--  DDL for Index TBL_AUTOR_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "PRUEBA_NEXOS"."TBL_AUTOR_PK" ON "PRUEBA_NEXOS"."TBL_AUTOR" ("IdAutor")
--------------------------------------------------------
--  DDL for Index TBL_LIBRO_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "PRUEBA_NEXOS"."TBL_LIBRO_PK" ON "PRUEBA_NEXOS"."TBL_LIBRO" ("IdLibro")
--------------------------------------------------------
--  Constraints for Table TBL_AUTOR
--------------------------------------------------------

  ALTER TABLE "PRUEBA_NEXOS"."TBL_AUTOR" MODIFY ("IdAutor" NOT NULL ENABLE)
  ALTER TABLE "PRUEBA_NEXOS"."TBL_AUTOR" MODIFY ("autNombreCompleto" NOT NULL ENABLE)
  ALTER TABLE "PRUEBA_NEXOS"."TBL_AUTOR" MODIFY ("autFchNacimiento" NOT NULL ENABLE)
  ALTER TABLE "PRUEBA_NEXOS"."TBL_AUTOR" MODIFY ("autCiudad" NOT NULL ENABLE)
  ALTER TABLE "PRUEBA_NEXOS"."TBL_AUTOR" MODIFY ("autCorreo" NOT NULL ENABLE)
  ALTER TABLE "PRUEBA_NEXOS"."TBL_AUTOR" ADD CONSTRAINT "TBL_AUTOR_PK" PRIMARY KEY ("IdAutor") USING INDEX "PRUEBA_NEXOS"."TBL_AUTOR_PK"  ENABLE
--------------------------------------------------------
--  Constraints for Table TBL_LIBRO
--------------------------------------------------------

  ALTER TABLE "PRUEBA_NEXOS"."TBL_LIBRO" MODIFY ("lbrTitulo" NOT NULL ENABLE)
  ALTER TABLE "PRUEBA_NEXOS"."TBL_LIBRO" MODIFY ("lbrAnio" NOT NULL ENABLE)
  ALTER TABLE "PRUEBA_NEXOS"."TBL_LIBRO" MODIFY ("lbrGenero" NOT NULL ENABLE)
  ALTER TABLE "PRUEBA_NEXOS"."TBL_LIBRO" MODIFY ("lbrNumPag" NOT NULL ENABLE)
  ALTER TABLE "PRUEBA_NEXOS"."TBL_LIBRO" ADD CONSTRAINT "TBL_LIBRO_PK" PRIMARY KEY ("IdLibro") USING INDEX "PRUEBA_NEXOS"."TBL_LIBRO_PK"  ENABLE
--------------------------------------------------------
--  Ref Constraints for Table TBL_LIBRO
--------------------------------------------------------

  ALTER TABLE "PRUEBA_NEXOS"."TBL_LIBRO" ADD CONSTRAINT "FK_LIBROS_CODIGO" FOREIGN KEY ("IdAutor") REFERENCES "PRUEBA_NEXOS"."TBL_AUTOR" ("IdAutor") ENABLE
