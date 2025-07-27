declare @tablename varchar(50) = 'Recipe'

declare @columnlist varchar(5000) = ''
select @columnlist = @columnlist + 
	concat('@',  c.COLUMN_NAME, ' ', c.DATA_TYPE , 
	case when c.CHARACTER_MAXIMUM_LENGTH is null then '' else concat( ' (', c.character_maximum_length, ')' )end,
	case when c.TABLE_NAME + 'id' = c.COLUMN_NAME then ' output' else '' end,
	',')
from INFORMATION_SCHEMA.columns c
where c.TABLE_NAME = @tablename

select @columnlist


declare @insertlist varchar(5000) = ''
select @insertlist = @insertlist + concat(c.COLUMN_NAME, ', ')
from INFORMATION_SCHEMA.columns c
where c.TABLE_NAME = @tablename
and c.COLUMN_NAME <> c.TABLE_NAME + 'id'

select @insertlist

select @insertlist = ''

select @insertlist = @insertlist + concat('@', c.COLUMN_NAME, ', ')
from INFORMATION_SCHEMA.columns c
where c.TABLE_NAME = @tablename
and c.COLUMN_NAME <> c.TABLE_NAME + 'id'

select @insertlist
select @insertlist = ''

select @insertlist = @insertlist + concat('@', c.column_name, ' = ', c.COLUMN_NAME, ', ')
from INFORMATION_SCHEMA.columns c
where c.TABLE_NAME = @tablename
and c.COLUMN_NAME <> c.TABLE_NAME + 'id'

select @insertlist
select @insertlist = ''

select @insertlist = @insertlist + concat('@' + c.column_name, ' = ','@', c.COLUMN_NAME, ', ')
from INFORMATION_SCHEMA.columns c
where c.TABLE_NAME = @tablename
and c.COLUMN_NAME <> c.TABLE_NAME + 'id'

select @insertlist