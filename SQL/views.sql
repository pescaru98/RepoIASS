CREATE OR REPLACE VIEW vw_cart_product AS
SELECT 
cp.cart_product_id,
cp.user_id,
cp.product_id,
cp.units as cart_units,
p.name,
p.price_per_unit,
p.picture,
p.units as product_units,
p.tag
from cart_product cp
JOIN users u ON u.user_id = cp.user_id
JOIN product p on p.product_id = cp.product_id;



CREATE OR REPLACE VIEW vw_feedback AS
SELECT 
fb.feedback_id,
fb.user_id,
fb.title,
fb.content,
fb.rating,
u.name,
u.surname,
u.email
FROM feedback fb
JOIN users u ON u.user_id = fb.user_id;


CREATE OR REPLACE VIEW vw_order_product AS
SELECT 
op.order_product_id,
op.order_set_id,
op.product_id,
op.units as bought_units,
op.current_price_per_unit as bought_price_per_unit,
os.user_id,
os.issue_date,
p.name as product_name,
u.name,
u.surname,
u.email
FROM order_product op
JOIN order_set os ON os.order_set_id = op.order_set_id
JOIN product p ON p.product_id = op.product_id
JOIN users u ON u.user_id = os.user_id;