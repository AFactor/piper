
RSpec.describe "Navigation API" do

  it "type=all should return everything" do
    json_hash = NavigationHelper.parse_response(NavigationHelper.get_all_levels)
    json_hash['type'].should eql 'all'
    json_hash['taxonomyId'].should be_empty
    json_hash['n'].should be_empty
    json_hash['ne'].should be_empty
    json_hash['children'].each do |child|
      child.should have_key('value')
      child['value'].should_not be_empty
      child['type'].should eql 'SuperDepartment'
      child['taxonomyId'].should_not be_empty
      child['n'].should_not be_empty
      child['ne'].should_not be_empty
      child['children'].each do |super_department_children|
        super_department_children.should have_key('value')
        super_department_children['value'].should_not be_empty
        super_department_children['type'].should eql 'Department'
        super_department_children['taxonomyId'].should_not be_empty
        super_department_children['n'].should_not be_empty
        super_department_children['ne'].should_not be_empty
        super_department_children['children'].each do |department_children|
          department_children.should have_key('value')
          department_children['value'].should_not be_empty
          department_children['type'].should eql 'Aisle'
          department_children['taxonomyId'].should_not be_empty
          department_children['n'].should_not be_empty
          department_children['ne'].should_not be_empty
          department_children['children'].each do |aisle_children|
            aisle_children.should have_key('value')
            aisle_children['value'].should_not be_empty
            aisle_children['type'].should eql 'Shelf'
            aisle_children['taxonomyId'].should_not be_empty
            aisle_children['n'].should_not be_empty
            aisle_children['ne'].should_not be_empty
          end
        end
      end
    end
  end

  it "type=superdepartment should return a list of super departments" do
    json_hash = NavigationHelper.parse_response(NavigationHelper.get_all_super_departments)
    json_hash['type'].should eql 'superdepartment'
    json_hash['taxonomyId'].should be_empty
    json_hash['n'].should be_empty
    json_hash['ne'].should be_empty
    json_hash['children'].each do |child|
      child.should have_key('value')
      child['value'].should_not be_empty
      child['type'].should eql 'SuperDepartment'
      child['taxonomyId'].should_not be_empty
      child['n'].should_not be_empty
      child['ne'].should_not be_empty
    end
  end

  it "type=department&taxonomyId=XXX should return a list of departments depending a taxonomyId" do
    taxonomy_id = NavigationHelper.parse_response(NavigationHelper.get_all_super_departments)['children'][0]['taxonomyId']
    json_hash = NavigationHelper.parse_response(NavigationHelper.get_all_departments_for(taxonomy_id))
    json_hash['type'].should eql 'department'
    json_hash['taxonomyId'].should eql taxonomy_id
    json_hash['children'].each do |child|
      child.should have_key('value')
      child['value'].should_not be_empty
      child['type'].should include 'Department'
      child['taxonomyId'].should_not be_empty
      child['n'].should_not be_empty
      child['ne'].should_not be_empty
    end
  end
end
