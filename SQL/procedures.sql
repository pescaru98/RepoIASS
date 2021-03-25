CREATE DEFINER=`root`@`localhost` PROCEDURE `order_create`(
	IN p_user_id INT,
    IN p_issue_date DATETIME,
    IN p_product_ids varchar(10000),
    IN p_units varchar(10000),
	IN p_current_price_per_units varchar(10000)
)
BEGIN
	DECLARE index_pos_product_ids INT;
    DECLARE index_pos_units INT;
    DECLARE index_pos_current_price_per_units INT;
	DECLARE p_order_set_id INT;
	DECLARE p_cpy_product_ids varchar(10000);
	DECLARE p_cpy_units varchar(10000);
	DECLARE p_cpy_current_price_per_units varchar(10000);
	
	
    DECLARE EXIT HANDLER FOR SQLEXCEPTION 
    BEGIN
		SHOW ERRORS;
          ROLLBACK;
    END;

    START TRANSACTION;
		SET p_cpy_product_ids = p_product_ids;
        SET p_cpy_units = p_units;
        SET p_cpy_current_price_per_units = p_current_price_per_units;
    
		INSERT INTO order_set (user_id, issue_date) values (p_user_id, p_issue_date);
		SET p_order_set_id = LAST_INSERT_ID();
		WHILE (CHAR_LENGTH(p_cpy_product_ids)) > 0 DO
			SET index_pos_product_ids = locate(',', p_cpy_product_ids);
			SET index_pos_units = locate(',', p_cpy_units);
			SET index_pos_current_price_per_units = locate(',', p_cpy_current_price_per_units);
			
			IF (index_pos_product_ids)>0 THEN
			BEGIN
				INSERT INTO order_product (product_id, order_set_id, units, current_price_per_unit) VALUES (substring(p_cpy_product_ids, 1, index_pos_product_ids - 1), p_order_set_id, substring(p_cpy_units, 1, index_pos_units - 1), substring(p_cpy_current_price_per_units, 1, index_pos_current_price_per_units - 1));
				
				SET p_cpy_product_ids = substring(p_cpy_product_ids, index_pos_product_ids + 1, CHAR_LENGTH(p_cpy_product_ids));
				SET p_cpy_units = substring(p_cpy_units, index_pos_units + 1, CHAR_LENGTH(p_cpy_units));
				SET p_cpy_current_price_per_units = substring(p_cpy_current_price_per_units, index_pos_current_price_per_units + 1, CHAR_LENGTH(p_cpy_current_price_per_units));
			END;
			ELSE
			BEGIN
      
				INSERT INTO order_product (product_id, order_set_id, units, current_price_per_unit) VALUES (p_cpy_product_ids, p_order_set_id, p_cpy_units, p_cpy_current_price_per_units);
				SET p_cpy_product_ids = "";
				SET p_cpy_units = "";
				SET p_cpy_current_price_per_units = "";
			END;
			END IF;
		END WHILE;
    COMMIT;

END