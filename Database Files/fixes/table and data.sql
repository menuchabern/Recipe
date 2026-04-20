--select * from recipe
alter table recipe add Skill int not null default 1 constraint ck_must_be_1_2_or_3 check(Skill between 1 and 3)
go
alter table recipe add SkillDesc as case when skill = 1 then 'beginner'
	when skill = 2 then 'intermediate'
	else 'advanced' end
go

alter table recipe add Vegan bit default 0 not null
go


;
with x as (
	select 'Chocolate Chip Cookies' as RecipeName, 2 as Skill, 1 as vegan
	union select 'Butter Muffins', 2 , 0
	union select 'Apple Yogurt Smoothie', 3, 1
	union select 'Breaded Chicken Breasts', 3, 0
	union select 'Sweet Potato Parsley Salad', 1, 0
	union select 'Fudgy Brownies', 1, 0
	union select 'Cheese Bread', 1, 1
)
update r
set r.Skill = x.skill, r.vegan = x.vegan
from recipe r
join x 
on x.RecipeName = r.RecipeName