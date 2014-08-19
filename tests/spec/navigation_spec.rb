
RSpec.describe "The Navigation API" do
  it "should return everything" do
    json_hash = NavigationHelper.parse_response(NavigationHelper.get_all_levels)
    json_hash['Children'].each do |child|
      child.should have_key('Name')
      child['LevelName'].should include 'SuperDepartment'
      child['Children'].each do |super_department_children|
        super_department_children.should have_key('Name')
        super_department_children['LevelName'].should include 'Department'
        super_department_children['Children'].each do |department_children|
          department_children.should have_key('Name')
          department_children['LevelName'].should include 'Aisle'
          department_children['Children'].each do |aisle_children|
            aisle_children.should have_key('Name')
            aisle_children['LevelName'].should include 'Shelf'
          end
        end
      end
    end
  end

  it "should return a list of super departments" do
    json_hash = NavigationHelper.parse_response(NavigationHelper.get_all_super_departments)
    json_hash['Children'].each do |child|
      child.should have_key('Name')
      child['LevelName'].should include 'SuperDepartment'
    end
  end

  it "should return a list of departments" do
    json_hash = NavigationHelper.parse_response(NavigationHelper.get_all_departments_for('TO_277265132'))
    json_hash['Children'].each do |child|
      child.should have_key('Name')
      child['LevelName'].should include 'Department'
    end
  end
end
