create procedure CreateContacto
    @Nombre varchar(100),
    @FechaNacimiento date,
    @Telefono varchar(9),
    @Observaciones varchar(500) = NULL
as
begin
    begin try
        begin transaction;
        insert into Contactos (
            Nombre,
            FechaNacimiento,
            Telefono,
            Observaciones
        ) values (
            @Nombre,
            @FechaNacimiento,
            @Telefono,
            @Observaciones
        );
 
        commit;
    end try;
    begin catch
        rollback;
        --log
    end catch;
end;