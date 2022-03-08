-- === STORED PROCEDURE ===
CREATE OR ALTER PROCEDURE [dbo].[ArtikelUitCategorie]
    @CatID smallint
AS
SELECT artikel, omschrijving, verkoopprijs
FROM artikel
WHERE cat_id = @CatID
ORDER BY artikel;