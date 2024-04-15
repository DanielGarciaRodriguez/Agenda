create procedure UpdateContacto
    @Id int,
    @Nombre varchar(100),
    @FechaNacimiento date,
    @Telefono varchar(9),
    @Observaciones varchar(500) = NULL
as
begin
    begin try
        begin transaction;
        update Contactos set 
            Nombre = @Nombre,
            FechaNacimiento = @FechaNacimiento,
            Telefono = @Telefono,
            Observaciones = @Observaciones
        ) where Id = @Id;
 
        commit;
    end try;
    begin catch
        rollback;
        --log
    end catch;
end;