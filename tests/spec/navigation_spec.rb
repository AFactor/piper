
RSpec.describe "Navigation API" do

  it "type=all should return everything" do
    json_hash = NavigationHelper.parse_response(NavigationHelper.get_all_levels)
    json_hash['Type'].should eql 'all'
    json_hash['TaxonomyId'].should be_empty
    json_hash['N'].should be_empty
    json_hash['Ne'].should be_empty
    json_hash['Children'].each do |child|
      child.should have_key('Name')
      child['Name'].should_not be_empty
      child['Type'].should eql 'SuperDepartment'
      child['TaxonomyId'].should_not be_empty
      child['N'].should_not be_empty
      child['Ne'].should_not be_empty
      child['Children'].each do |super_department_children|
        super_department_children.should have_key('Name')
        super_department_children['Name'].should_not be_empty
        super_department_children['Type'].should eql 'Department'
        super_department_children['TaxonomyId'].should_not be_empty
        super_department_children['N'].should_not be_empty
        super_department_children['Ne'].should_not be_empty
        super_department_children['Children'].each do |department_children|
          department_children.should have_key('Name')
          department_children['Name'].should_not be_empty
          department_children['Type'].should eql 'Aisle'
          department_children['TaxonomyId'].should_not be_empty
          department_children['N'].should_not be_empty
          department_children['Ne'].should_not be_empty
          department_children['Children'].each do |aisle_children|
            aisle_children.should have_key('Name')
            aisle_children['Name'].should_not be_empty
            aisle_children['Type'].should eql 'Shelf'
            aisle_children['TaxonomyId'].should_not be_empty
            aisle_children['N'].should_not be_empty
            aisle_children['Ne'].should_not be_empty
          end
        end
      end
    end
  end

  it "type=superdepartment should return a list of super departments" do
    json_hash = NavigationHelper.parse_response(NavigationHelper.get_all_super_departments)
    json_hash['Type'].should eql 'superdepartment'
    json_hash['TaxonomyId'].should be_empty
    json_hash['N'].should be_empty
    json_hash['Ne'].should be_empty
    json_hash['Children'].each do |child|
      child.should have_key('Name')
      child['Name'].should_not be_empty
      child['Type'].should eql 'SuperDepartment'
      child['TaxonomyId'].should_not be_empty
      child['N'].should_not be_empty
      child['Ne'].should_not be_empty
    end
  end

  it "type=department&taxonomyid=XXX should return a list of departments depending a TaxonomyId" do
    taxonomy_id = NavigationHelper.parse_response(NavigationHelper.get_all_super_departments)['Children'][0]['TaxonomyId']
    json_hash = NavigationHelper.parse_response(NavigationHelper.get_all_departments_for(taxonomy_id))
    json_hash['Type'].should eql 'department'
    json_hash['TaxonomyId'].should eql taxonomy_id
    json_hash['Children'].each do |child|
      child.should have_key('Name')
      child['Name'].should_not be_empty
      child['Type'].should include 'Department'
      child['TaxonomyId'].should_not be_empty
      child['N'].should_not be_empty
      child['Ne'].should_not be_empty
    end
  end
end
